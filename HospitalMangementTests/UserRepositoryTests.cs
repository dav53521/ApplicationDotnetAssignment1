using ApplicationDotnetAssignment1.Contexts;
using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMangementTests
{
    public class UserRepositoryTests
    {
        [Test]
        public void UserRepositoryCanGetAllUsersInContext()
        {
            List<User> result = unitOfWork.UserRepository.GetAllUsers();

            Assert.That(result.Count(), Is.EqualTo(6));
            Assert.That(result, Is.SupersetOf(doctorData));
            Assert.That(result, Is.SupersetOf(adminData));
            Assert.That(result, Is.SupersetOf(patientData));
        }

        [Test]
        public void UserRepositoryCannotGetUsersThatAreNotInContext()
        {
            Doctor nonDbUser = new Doctor
            {
                Id = 11000,
                Name = "Test test",
                Email = "test@test.com",
                Password = "123",
                Address = "22 test sydney nsw 2000",
                PhoneNumber = "1234567890",
            };

            List<User> result = unitOfWork.UserRepository.GetAllUsers();

            Assert.That(result, Does.Not.Contain(nonDbUser));
        }

        [Test]
        public void UserRepositoryCanFindUsersById()
        {
            User? foundDoctor = unitOfWork.UserRepository.GetUserById(11000);
            User? foundPatient = unitOfWork.UserRepository.GetUserById(20000);
            User? foundAdmin = unitOfWork.UserRepository.GetUserById(10000);

            AssertThatUserCredentalsAreCorrect(foundDoctor, 11000, "Test1", "1231", "11000@test.com", "20 test sydney nsw 2000", "1234567890");
            //AssertThatUserCredentalsAreCorrect(foundPatient, 20000, "Test3", "1233", "20000@test.com");
        }

        void AssertThatUserCredentalsAreCorrect(User? userToCheck, int expectedId, string expectedName, string expectedPassword, string expectedEmail, string expectedAddress, string expectedPhoneNumber)
        {
            Assert.That(userToCheck, Is.Not.Null);
            Assert.That(userToCheck.Id, Is.EqualTo(expectedId));
            Assert.That(userToCheck.Name, Is.EqualTo(expectedName));
            Assert.That(userToCheck.Password, Is.EqualTo(expectedPassword));
            Assert.That(userToCheck.Address, Is.EqualTo(expectedAddress));
            Assert.That(userToCheck.PhoneNumber, Is.EqualTo(expectedPhoneNumber));
        }


        [SetUp]
        public void Setup()
        {
            doctorData = new List<Doctor>
            {
                new Doctor
                {
                    Id = 11000,
                    Name = "Test1",
                    Email = "11000@test.com",
                    Password = "1231",
                    Address = "20 test sydney nsw 2000",
                    PhoneNumber = "1234567890",
                },
                new Doctor
                {
                    Id = 11001,
                    Name = "Test2",
                    Email = "11001@test.com",
                    Password = "1232",
                    Address = "21 test sydney nsw 2000",
                    PhoneNumber = "1234567891",
                }
            }.AsQueryable();

            patientData = new List<Patient>
            {
                new Patient
                {
                    Id = 20000,
                    Name = "Test3",
                    Email = "20000@test.com",
                    Password = "1233",
                    Address = "22 test sydney nsw 2000",
                    PhoneNumber = "1234567892",
                },
                new Patient
                {
                    Id = 20001,
                    Name = "test4",
                    Email = "20001@test.com",
                    Password = "123",
                    Address = "23 test sydney nsw 2000",
                    PhoneNumber = "1234567893",
                }
            }.AsQueryable();

            adminData = new List<Admin>
            {
                new Admin
                {
                    Id = 10000,
                    Password = "1234",
                    Name = "test5",
                    Email = "10000@test.com",
                    Address = "24 test sydney nsw 2000",
                    PhoneNumber = "1234567894",

                },
                new Admin
                {
                    Id = 10001,
                    Password = "1235",
                    Name = "test6",
                    Email = "10001@test.com",
                    Address = "25 test sydney nsw 2000",
                    PhoneNumber = "1234567895",
                }
            }.AsQueryable();

            Mock<DbSet<Doctor>> mockDoctorSet = new Mock<DbSet<Doctor>>();
            mockDoctorSet.As<IQueryable<Doctor>>().Setup(m => m.Provider).Returns(doctorData.Provider);
            mockDoctorSet.As<IQueryable<Doctor>>().Setup(m => m.Expression).Returns(doctorData.Expression);
            mockDoctorSet.As<IQueryable<Doctor>>().Setup(m => m.ElementType).Returns(doctorData.ElementType);
            mockDoctorSet.As<IQueryable<Doctor>>().Setup(m => m.GetEnumerator()).Returns(() => doctorData.GetEnumerator());

            Mock<DbSet<Patient>> mockPatientSet = new Mock<DbSet<Patient>>();
            mockPatientSet.As<IQueryable<Patient>>().Setup(m => m.Provider).Returns(patientData.Provider);
            mockPatientSet.As<IQueryable<Patient>>().Setup(m => m.Expression).Returns(patientData.Expression);
            mockPatientSet.As<IQueryable<Patient>>().Setup(m => m.ElementType).Returns(patientData.ElementType);
            mockPatientSet.As<IQueryable<Patient>>().Setup(m => m.GetEnumerator()).Returns(() => patientData.GetEnumerator());

            Mock<DbSet<Admin>> mockAdminSet = new Mock<DbSet<Admin>>();
            mockAdminSet.As<IQueryable<Admin>>().Setup(m => m.Provider).Returns(adminData.Provider);
            mockAdminSet.As<IQueryable<Admin>>().Setup(m => m.Expression).Returns(adminData.Expression);
            mockAdminSet.As<IQueryable<Admin>>().Setup(m => m.ElementType).Returns(adminData.ElementType);
            mockAdminSet.As<IQueryable<Admin>>().Setup(m => m.GetEnumerator()).Returns(() => adminData.GetEnumerator());

            Mock<HospitalSystemContext> mockContext = new Mock<HospitalSystemContext>();
            mockContext.SetupGet(m => m.Doctors).Returns(mockDoctorSet.Object);
            mockContext.SetupGet(m => m.Patients).Returns(mockPatientSet.Object);
            mockContext.SetupGet(m => m.Admins).Returns(mockAdminSet.Object);

            unitOfWork = new HospitalSystemUnitOfWork(mockContext.Object);
        }

        IQueryable<Doctor> doctorData;
        IQueryable<Patient> patientData;
        IQueryable<Admin> adminData;

        HospitalSystemUnitOfWork unitOfWork;
    }
}
