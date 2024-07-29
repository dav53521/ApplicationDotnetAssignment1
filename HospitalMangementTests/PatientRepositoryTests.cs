using ApplicationDotnetAssignment1.Contexts;
using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.Repositories;
using ApplicationDotnetAssignment1.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMangementTests
{
    public class PatientRepositoryTests
    {
        [Test]
        public void TestGetAllPatients()
        {
            List<Patient> actual = _PatientRepository.GetAllPatients();
            Assert.That(actual, Is.EquivalentTo(_PatientData)); //Asserting that both collections have the same data
        }

        [Test]
        public void TestDoesNotGetPatientsThatAreNotInDb()
        {
            //Creating a patient that is not in the set which should replicate having an entity that is not in the Db
            Patient nonDbPatient = new Patient
            {
                Id = 10005,
                Name = "Test5",
                Email = "10005@test.com",
                Password = "1235",
                Address = "21 test sydney nsw 2000",
                PhoneNumber = "1234567893",
            };

            List<Patient> actual = _PatientRepository.GetAllPatients();
            Assert.That(actual, Does.Not.Contain(nonDbPatient));
        }

        [Test]
        public void TestGetAllPatientsDoesNotGetUsersThatAreNotPatients()
        {
            List<Patient> actual = _PatientRepository.GetAllPatients();
            Assert.That(actual, Does.Not.Contains(_DoctorData)); //Asserting that the function for getting all patients only gets patients
        }

        [Test]
        public void TestThatPatientsCanBeGottenUsingId()
        {
            Patient? actual = _PatientRepository.GetPatientById(10000);
            AssertThatPatientDetailsAreCorrect(actual, 10000, "Test1", "1231", "10000@test.com", "20 test sydney nsw 2000", "1234567890"); //Assert that the right patient has been selected
        }

        [Test]
        public void TestThatNoPatientsAreGottenWithInvalidId()
        {
            Patient? actual = _PatientRepository.GetPatientById(10010);
            Assert.That(actual, Is.Null); //Invalid id has been given so no result should be returned
        }

        [Test]
        public void TestThatPatientsCanBeFoundUsingDelegate()
        {
            List<Patient> actual = _PatientRepository.FindPatients(d => d.Address == "20 test sydney nsw 2000").OrderBy(d => d.Id).ToList(); //Ordering the data so that there's no randomness in how the data is selected
            Assert.That(actual.Count, Is.EqualTo(2));
            //Asserting that both patients with the address have been found
            AssertThatPatientDetailsAreCorrect(actual[0], 10000, "Test1", "1231", "10000@test.com", "20 test sydney nsw 2000", "1234567890");
            AssertThatPatientDetailsAreCorrect(actual[1], 10002, "Test3", "1233", "10002@test.com", "20 test sydney nsw 2000", "1234567892");
        }

        [Test]
        public void TestThatPatientsWillNotBeFoundIfTheyDoNotMeetRequirements()
        {
            List<Patient> actual = _PatientRepository.FindPatients(d => d.Address == "20 test sydney nsw 2000" && d.Id == 10000).OrderBy(d => d.Id).ToList(); //Ordering the data so that there's no randomness in how the data is selected
            Assert.That(actual.Count, Is.EqualTo(1));
            Assert.That(actual, Does.Not.Contain(_PatientData.Where(d => d.Id == 10002))); //Checking that the actual result does not contain the other user with the same address
        }

        //The below method is a helper method for asserting whether a user has been gotten correctly as there's no point in repeating the same assertions multiple times
        void AssertThatPatientDetailsAreCorrect(Patient? userToCheck, int expectedId, string expectedName, string expectedPassword, string expectedEmail, string expectedAddress, string expectedPhoneNumber)
        {
            Assert.That(userToCheck, Is.Not.Null);
            Assert.That(userToCheck.Id, Is.EqualTo(expectedId));
            Assert.That(userToCheck.Name, Is.EqualTo(expectedName));
            Assert.That(userToCheck.Password, Is.EqualTo(expectedPassword));
            Assert.That(userToCheck.Address, Is.EqualTo(expectedAddress));
            Assert.That(userToCheck.PhoneNumber, Is.EqualTo(expectedPhoneNumber));
        }

        [Test]
        public void TestThatAddingPatientWillAddAndSavePatientInContext()
        {
            Patient patientToAdd = new Patient
            {
                Id = 10005,
                Name = "Test5",
                Email = "10005@test.com",
                Password = "1235",
                Address = "21 test sydney nsw 2000",
                PhoneNumber = "1234567893",
            };

            _PatientRepository.AddPatient(patientToAdd);

            //Asserting that the patient has been added and saved after the AddPatient function has been called
            _MockPatientSet.Verify(m => m.Add(It.IsAny<Patient>()), Times.Once());
            _MockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Test]
        public void TestThatUpdatingPatientWillUpdateAndSavePatientInContext()
        {
            Patient patientToUpdate = _PatientData.FirstOrDefault()!;

            _PatientRepository.UpdatePatient(patientToUpdate);

            //Asserting that the patient has been updated and saved after the UpdatePatient function has been called
            _MockPatientSet.Verify(m => m.Update(It.IsAny<Patient>()), Times.Once());
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
                    Id = 10000,
                    Name = "Test1",
                    Email = "10000@test.com",
                    Password = "1231",
                    Address = "20 test sydney nsw 2000",
                    PhoneNumber = "1234567890",
                },
                new Patient
                {
                    Id = 10001,
                    Name = "Test2",
                    Email = "10001@test.com",
                    Password = "1232",
                    Address = "21 test sydney nsw 2000",
                    PhoneNumber = "1234567891",
                },
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

            _DoctorData = new List<Doctor>
            {
                new Doctor
                {
                    Id = 20000,
                    Name = "Test3",
                    Email = "20000@test.com",
                    Password = "1233",
                    Address = "20 test sydney nsw 2000",
                    PhoneNumber = "1234567892",
                }
            }.AsQueryable();

            _MockPatientSet = new Mock<DbSet<Patient>>();
            _MockPatientSet.As<IQueryable<Patient>>().Setup(m => m.Provider).Returns(_PatientData.Provider);
            _MockPatientSet.As<IQueryable<Patient>>().Setup(m => m.Expression).Returns(_PatientData.Expression);
            _MockPatientSet.As<IQueryable<Patient>>().Setup(m => m.ElementType).Returns(_PatientData.ElementType);
            _MockPatientSet.As<IQueryable<Patient>>().Setup(m => m.GetEnumerator()).Returns(() => _PatientData.GetEnumerator());

            Mock<DbSet<Doctor>> mockDoctorSet = new Mock<DbSet<Doctor>>();
            mockDoctorSet.As<IQueryable<Doctor>>().Setup(m => m.Provider).Returns(_DoctorData.Provider);
            mockDoctorSet.As<IQueryable<Doctor>>().Setup(m => m.Expression).Returns(_DoctorData.Expression);
            mockDoctorSet.As<IQueryable<Doctor>>().Setup(m => m.ElementType).Returns(_DoctorData.ElementType);
            mockDoctorSet.As<IQueryable<Doctor>>().Setup(m => m.GetEnumerator()).Returns(() => _DoctorData.GetEnumerator());

            _MockContext = new Mock<HospitalSystemContext>();
            _MockContext.Setup(m => m.Set<Doctor>()).Returns(mockDoctorSet.Object);
            _MockContext.Setup(m => m.Set<Patient>()).Returns(_MockPatientSet.Object);

            _PatientRepository = new HospitalSystemUnitOfWork(_MockContext.Object).PatientRepository;
        }

        Mock<HospitalSystemContext> _MockContext;
        Mock<DbSet<Patient>> _MockPatientSet;
        IQueryable<Patient> _PatientData;
        IQueryable<Doctor> _DoctorData;
        PatientRepository _PatientRepository;
    }
}
