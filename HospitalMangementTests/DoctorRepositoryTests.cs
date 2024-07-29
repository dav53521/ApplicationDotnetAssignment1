using ApplicationDotnetAssignment1.Contexts;
using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.Repositories;
using ApplicationDotnetAssignment1.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using EntityFramework.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMangementTests
{
    public class DoctorRepositoryTests
    {
        [Test]
        public void TestGetAllDoctors()
        {
            List<Doctor> actual = _DoctorRepository.GetAllDoctors();
            Assert.That(actual, Is.EquivalentTo(_DoctorData)); //Asserting that both collections have the same data
        }

        [Test]
        public void TestDoesNotGetDoctorsThatAreNotInDb()
        {
            //Creating a doctor that is not in the set which should replicate having an entity that is not in the Db
            Doctor nonDbDoctor = new Doctor
            {
                Id = 10005,
                Name = "Test5",
                Email = "10005@test.com",
                Password = "1235",
                Address = "21 test sydney nsw 2000",
                PhoneNumber = "1234567893",
            };

            List<Doctor> actual = _DoctorRepository.GetAllDoctors();
            Assert.That(actual, Does.Not.Contain(nonDbDoctor));
        }

        [Test]
        public void TestGetAllDoctorsDoesNotGetUsersThatAreNotDoctors()
        {
            List<Doctor> actual = _DoctorRepository.GetAllDoctors();
            Assert.That(actual, Does.Not.Contains(_PatientData)); //Asserting that the function for getting all doctors only gets doctors
        }

        [Test]
        public void TestThatDoctorCanBeGottenUsingId()
        {
            Doctor? actual = _DoctorRepository.GetDoctorById(10000);
            AssertThatDoctorDetailsAreCorrect(actual, 10000, "Test1", "1231", "10000@test.com", "20 test sydney nsw 2000", "1234567890"); //Assert that the right doctor has been gotten
        }

        [Test]
        public void TestThatNoDoctorsAreGottenWithInvalidId()
        {
            Doctor? actual = _DoctorRepository.GetDoctorById(10010); 
            Assert.That(actual, Is.Null); //Invalid id has been given so no result should be returned
        }

        [Test]
        public void TestThatDoctorsCanBeFoundUsingDelegate()
        {
            List<Doctor> actual = _DoctorRepository.FindDoctors(d => d.Address == "20 test sydney nsw 2000").OrderBy(d => d.Id).ToList(); //Ordering the data so that there's no randomness in how the data is gotten
            Assert.That(actual.Count, Is.EqualTo(2));
            //Asserting that both doctors with the address have been found
            AssertThatDoctorDetailsAreCorrect(actual[0], 10000, "Test1", "1231", "10000@test.com", "20 test sydney nsw 2000", "1234567890");
            AssertThatDoctorDetailsAreCorrect(actual[1], 10002, "Test3", "1233", "10002@test.com", "20 test sydney nsw 2000", "1234567892");
        }

        [Test]
        public void TestThatDoctorsWillNotBeFoundIfTheyDoNotMeetRequirements()
        {
            List<Doctor> actual = _DoctorRepository.FindDoctors(d => d.Address == "20 test sydney nsw 2000" && d.Id == 10000).OrderBy(d => d.Id).ToList(); //Ordering the data so that there's no randomness in how the data is gotten
            Assert.That(actual.Count, Is.EqualTo(1));
            Assert.That(actual, Does.Not.Contain(_DoctorData.Where(d => d.Id == 10002))); //Checking that the actual result does not contain the other user with the same address
        }

        //The below method is a helper method for asserting whether a user has been gotten correctly as there's no point in repeating the same assertions multiple times
        void AssertThatDoctorDetailsAreCorrect(Doctor? userToCheck, int expectedId, string expectedName, string expectedPassword, string expectedEmail, string expectedAddress, string expectedPhoneNumber)
        {
            Assert.That(userToCheck, Is.Not.Null);
            Assert.That(userToCheck.Id, Is.EqualTo(expectedId));
            Assert.That(userToCheck.Name, Is.EqualTo(expectedName));
            Assert.That(userToCheck.Password, Is.EqualTo(expectedPassword));
            Assert.That(userToCheck.Address, Is.EqualTo(expectedAddress));
            Assert.That(userToCheck.PhoneNumber, Is.EqualTo(expectedPhoneNumber));
        }

        [Test]
        public void TestThatAddingDoctorWillAddAndSaveDoctorInContext()
        {
            Doctor doctorToAdd = new Doctor
            {
                Id = 10005,
                Name = "Test5",
                Email = "10005@test.com",
                Password = "1235",
                Address = "21 test sydney nsw 2000",
                PhoneNumber = "1234567893",
            };

            _DoctorRepository.AddDoctor(doctorToAdd);
            
            //Asserting that the doctor has been added and saved after the AddDoctor function has been called
            _MockDoctorSet.Verify(m => m.Add(It.IsAny<Doctor>()), Times.Once());
            _MockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        //This setup is being used to reduce the need for repeating code as almost all tests will be using the same data and will need the same mocks to occur
        [SetUp]
        public void Setup()
        {
            _DoctorData = new List<Doctor>
            {
                new Doctor
                {
                    Id = 10000,
                    Name = "Test1",
                    Email = "10000@test.com",
                    Password = "1231",
                    Address = "20 test sydney nsw 2000",
                    PhoneNumber = "1234567890",
                },
                new Doctor
                {
                    Id = 10001,
                    Name = "Test2",
                    Email = "10001@test.com",
                    Password = "1232",
                    Address = "21 test sydney nsw 2000",
                    PhoneNumber = "1234567891",
                },
                new Doctor
                {
                    Id = 10002,
                    Name = "Test3",
                    Email = "10002@test.com",
                    Password = "1233",
                    Address = "20 test sydney nsw 2000",
                    PhoneNumber = "1234567892",
                },
                new Doctor
                {
                    Id = 10003,
                    Name = "Test4",
                    Email = "10003@test.com",
                    Password = "1234",
                    Address = "21 test sydney nsw 2000",
                    PhoneNumber = "1234567893",
                }
            }.AsQueryable();

            _PatientData = new List<Patient>
            {
                new Patient
                {
                    Id = 20000,
                    Name = "Test3",
                    Email = "20000@test.com",
                    Password = "1233",
                    Address = "20 test sydney nsw 2000",
                    PhoneNumber = "1234567892",
                }
            }.AsQueryable();

            _MockDoctorSet = new Mock<DbSet<Doctor>>();
            _MockDoctorSet.As<IQueryable<Doctor>>().Setup(m => m.Provider).Returns(_DoctorData.Provider);
            _MockDoctorSet.As<IQueryable<Doctor>>().Setup(m => m.Expression).Returns(_DoctorData.Expression);
            _MockDoctorSet.As<IQueryable<Doctor>>().Setup(m => m.ElementType).Returns(_DoctorData.ElementType);
            _MockDoctorSet.As<IQueryable<Doctor>>().Setup(m => m.GetEnumerator()).Returns(() => _DoctorData.GetEnumerator());

            Mock<DbSet<Patient>> mockPatientSet = new Mock<DbSet<Patient>>();
            mockPatientSet.As<IQueryable<Patient>>().Setup(m => m.Provider).Returns(_PatientData.Provider);
            mockPatientSet.As<IQueryable<Patient>>().Setup(m => m.Expression).Returns(_PatientData.Expression);
            mockPatientSet.As<IQueryable<Patient>>().Setup(m => m.ElementType).Returns(_PatientData.ElementType);
            mockPatientSet.As<IQueryable<Patient>>().Setup(m => m.GetEnumerator()).Returns(() => _PatientData.GetEnumerator());

            _MockContext = new Mock<HospitalSystemContext>();
            _MockContext.Setup(m => m.Set<Doctor>()).Returns(_MockDoctorSet.Object);
            _MockContext.Setup(m => m.Set<Patient>()).Returns(mockPatientSet.Object);

            _DoctorRepository = new HospitalSystemUnitOfWork(_MockContext.Object).DoctorRepository;
        }

        Mock<HospitalSystemContext> _MockContext;
        Mock<DbSet<Doctor>> _MockDoctorSet;
        IQueryable<Doctor> _DoctorData;
        IQueryable<Patient> _PatientData;
        DoctorRepository _DoctorRepository;
    }
}
