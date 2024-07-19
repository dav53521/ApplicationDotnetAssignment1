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
        public void UserRegistryCanGetAllUsers()
        {
            List<User> result = unitOfWork.UserRepository.GetAllUsers();

            Assert.That(result.Count(), Is.EqualTo(6));
            Assert.That(result, Is.SupersetOf(doctorData));
            Assert.That(result, Is.SupersetOf(adminData));
            Assert.That(result, Is.SupersetOf(patientData));
        }


        [SetUp]
        public void Setup()
        {
            doctorData = new List<Doctor>
            {
                new Doctor
                {
                    Id = 11,
                    Name = "Test test",
                    Email = "test@test.com",
                    Password = "123",
                    Address = "21 test sydney nsw 2000",
                },
                new Doctor
                {
                    Id = 12,
                    Name = "Test test",
                    Email = "test@test.com",
                    Password = "123",
                    Address = "21 test sydney nsw 2000",
                }
            }.AsQueryable();

            patientData = new List<Patient>
            {
                new Patient
                {
                    Id = 21,
                    Name = "Test test",
                    Email = "test@test.com",
                    Password = "123",
                    Address = "21 test sydney nsw 2000",
                },
                new Patient
                {
                    Id = 22,
                    Name = "Test test",
                    Email = "test@test.com",
                    Password = "123",
                    Address = "21 test sydney nsw 2000",
                }
            }.AsQueryable();

            adminData = new List<Admin>
            {
                new Admin
                {
                    Id = 1,
                    Password = "123",
                },
                new Admin
                {
                    Id = 2,
                    Password = "123",
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
