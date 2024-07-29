using ApplicationDotnetAssignment1.Contexts;
using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.Repositories;
using ApplicationDotnetAssignment1.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace HospitalMangementTests
{
    public class AppointmentRepositoryTest
    {
        [Test]
        public void TestGetAllAppointments()
        {
            List<Appointment> actual = _AppointmentRepository.GetAllAppointments();

            Assert.That(actual, Is.EquivalentTo(_AppointmentData)); //Asserting that both collections have the same data
        }

        [Test]
        public void TestDoesNotGetAppointmentsThatAreNotInDb()
        {
            //Creating a Appointment that is not in the set which should replicate having an entity that is not in the Db
            Appointment nonDbAppointment = new Appointment
            {
                Id = 10005,
                PatientId = 10003,
                DoctorId = 10001,
                Description = "Test5"
            };

            List<Appointment> actual = _AppointmentRepository.GetAllAppointments();

            Assert.That(actual, Does.Not.Contain(nonDbAppointment));
        }

        [Test]
        public void TestGetAllAppointmentsDoesNotGetUsersThatAreNotAppointments()
        {
            List<Appointment> actual = _AppointmentRepository.GetAllAppointments();

            Assert.That(actual, Does.Not.Contains(_PatientData)); //Asserting that the function for getting all Appointments only gets Appointments
        }

        [Test]
        public void TestThatAppointmentCanBeGottenUsingId()
        {
            Appointment? actual = _AppointmentRepository.GetAppointmentById(10000);

            AssertThatAppointmentDetailsAreCorrect(actual, 10000, 30000, 20000, "Test1"); //Assert that the right Appointment has been gotten
        }

        [Test]
        public void TestThatNoAppointmentsAreGottenWithInvalidId()
        {
            Appointment? actual = _AppointmentRepository.GetAppointmentById(10010);

            Assert.That(actual, Is.Null); //Invalid id has been given so no result should be returned
        }

        [Test]
        public void TestThatAppointmentsCanBeFoundUsingDelegate()
        {
            List<Appointment> actual = _AppointmentRepository.FindAppointments(a => a.DoctorId == 30000).OrderBy(a => a.Id).ToList(); //Ordering the data so that there's no randomness in how the data is gotten
            Assert.That(actual.Count, Is.EqualTo(2));

            //Asserting that both Appointments with the address have been found
            AssertThatAppointmentDetailsAreCorrect(actual[0], 10000, 30000, 20000, "Test1");
            AssertThatAppointmentDetailsAreCorrect(actual[1], 10001, 30000, 20001, "Test2");
        }

        [Test]
        public void TestThatAppointmentsWillNotBeFoundIfTheyDoNotMeetRequirements()
        {
            List<Appointment> actual = _AppointmentRepository.FindAppointments(a => a.DoctorId == 30000 && a.Id == 10000).OrderBy(a => a.Id).ToList(); //Ordering the data so that there's no randomness in how the data is gotten

            Assert.That(actual.Count, Is.EqualTo(1));
            Assert.That(actual, Does.Not.Contain(_AppointmentData.Where(a => a.Id == 10002))); //Checking that the actual result does not contain the other user with the same address
            AssertThatAppointmentDetailsAreCorrect(actual[0], 10000, 30000, 20000, "Test1");
        }

        //The below method is a helper method for asserting whether a user has been gotten correctly as there's no point in repeating the same assertions multiple times
        void AssertThatAppointmentDetailsAreCorrect(Appointment? appointmentToCheck, int expectedId, int expectedDoctorId, int expectedPatientId, string description)
        {
            Assert.That(appointmentToCheck, Is.Not.Null);
            Assert.That(appointmentToCheck.Id, Is.EqualTo(expectedId));
            Assert.That(appointmentToCheck.PatientId, Is.EqualTo(expectedPatientId));
            Assert.That(appointmentToCheck.DoctorId, Is.EqualTo(expectedDoctorId));
            Assert.That(appointmentToCheck.Description, Is.EqualTo(description));
        }

        [Test]
        public void TestThatAddingAppointmentWillAddAndSaveAppointmentInContext()
        {
            Appointment appointmentToAdd = new Appointment
            {
                Id = 10005,
                PatientId = 10003,
                DoctorId = 10001,
                Description = "Test5"
            };

            _AppointmentRepository.AddAppointment(appointmentToAdd);

            //Asserting that the Appointment has been added and saved after the AddAppointment function has been called
            _MockAppointmentSet.Verify(m => m.Add(It.IsAny<Appointment>()), Times.Once());
            _MockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        //This setup is being used to reduce the need for repeating code as almost all tests will be using the same data and will need the same mocks to occur
        [SetUp]
        public void Setup()
        {
            _PatientData = new List<Patient>
            {
                new Patient
                {
                    Id = 10002,
                    Name = "Test3",
                    Email = "10002@test.com",
                    Password = "1233",
                    Address = "20 test sydney nsw 2000",
                    PhoneNumber = "1234567892",
                },
                new Patient
                {
                    Id = 10003,
                    Name = "Test4",
                    Email = "10003@test.com",
                    Password = "1234",
                    Address = "21 test sydney nsw 2000",
                    PhoneNumber = "1234567893",
                }
            }.AsQueryable();

            _AppointmentData = new List<Appointment>
            { 
                new Appointment
                {
                    Id = 10000,
                    PatientId = 20000,
                    DoctorId = 30000,
                    Description = "Test1"
                },
                new Appointment
                {
                    Id = 10001,
                    PatientId = 20001,
                    DoctorId = 30000,
                    Description = "Test2"
                },
                new Appointment
                {
                    Id = 10002,
                    PatientId = 20002,
                    DoctorId = 30001,
                    Description = "Test3"
                },
                new Appointment
                {
                    Id = 10003,
                    PatientId = 20003,
                    DoctorId = 30001,
                    Description = "Test3"
                },
            }.AsQueryable();
             


            _MockAppointmentSet = new Mock<DbSet<Appointment>>();
            _MockAppointmentSet.As<IQueryable<Appointment>>().Setup(m => m.Provider).Returns(_AppointmentData.Provider);
            _MockAppointmentSet.As<IQueryable<Appointment>>().Setup(m => m.Expression).Returns(_AppointmentData.Expression);
            _MockAppointmentSet.As<IQueryable<Appointment>>().Setup(m => m.ElementType).Returns(_AppointmentData.ElementType);
            _MockAppointmentSet.As<IQueryable<Appointment>>().Setup(m => m.GetEnumerator()).Returns(() => _AppointmentData.GetEnumerator());

            Mock<DbSet<Patient>> mockPatientSet = new Mock<DbSet<Patient>>();
            mockPatientSet.As<IQueryable<Patient>>().Setup(m => m.Provider).Returns(_PatientData.Provider);
            mockPatientSet.As<IQueryable<Patient>>().Setup(m => m.Expression).Returns(_PatientData.Expression);
            mockPatientSet.As<IQueryable<Patient>>().Setup(m => m.ElementType).Returns(_PatientData.ElementType);
            mockPatientSet.As<IQueryable<Patient>>().Setup(m => m.GetEnumerator()).Returns(() => _PatientData.GetEnumerator());

            _MockContext = new Mock<HospitalSystemContext>();
            _MockContext.Setup(m => m.Set<Appointment>()).Returns(_MockAppointmentSet.Object);
            _MockContext.Setup(m => m.Set<Patient>()).Returns(mockPatientSet.Object);

            _AppointmentRepository = new HospitalSystemUnitOfWork(_MockContext.Object).AppointmentRepository;
        }

        Mock<HospitalSystemContext> _MockContext;
        Mock<DbSet<Appointment>> _MockAppointmentSet;
        IQueryable<Patient> _PatientData;
        IQueryable<Appointment> _AppointmentData;
        AppointmentRepository _AppointmentRepository;
    }
}
