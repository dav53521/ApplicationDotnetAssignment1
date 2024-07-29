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
    public class DoctorRepositoryTests
    {
        [Test]
        public void TestGetAllDoctors()
        {
            List<Doctor> actual = _doctorRepository.GetAllDoctors();
            Assert.That(actual, Is.EquivalentTo(_doctorData)); //Asserting that both containers have the same data
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

            List<Doctor> actual = _doctorRepository.GetAllDoctors();
            Assert.That(actual, Does.Not.Contain(nonDbDoctor));
        }

        [Test]
        public void TestGetAllDoctorsDoesNotGetUsersThatAreNotDoctors()
        {
            List<Doctor> actual = _doctorRepository.GetAllDoctors();
            Assert.That(actual, Does.Not.Contains(_patientData)); //Asserting that the function for getting all doctors only gets doctors
        }

        //This setup is being used to reduce the need for repeating code as almost all tests will be using the same data and will need the same mocks to occur
        [SetUp]
        public void Setup()
        {
            _doctorData = new List<Doctor>
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

            _patientData = new List<Patient>
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

            Mock<DbSet<Doctor>> mockDoctorSet = new Mock<DbSet<Doctor>>();
            mockDoctorSet.As<IQueryable<Doctor>>().Setup(m => m.Provider).Returns(_doctorData.Provider);
            mockDoctorSet.As<IQueryable<Doctor>>().Setup(m => m.Expression).Returns(_doctorData.Expression);
            mockDoctorSet.As<IQueryable<Doctor>>().Setup(m => m.ElementType).Returns(_doctorData.ElementType);
            mockDoctorSet.As<IQueryable<Doctor>>().Setup(m => m.GetEnumerator()).Returns(() => _doctorData.GetEnumerator());

            Mock<DbSet<Patient>> mockPatientSet = new Mock<DbSet<Patient>>();
            mockPatientSet.As<IQueryable<Patient>>().Setup(m => m.Provider).Returns(_patientData.Provider);
            mockPatientSet.As<IQueryable<Patient>>().Setup(m => m.Expression).Returns(_patientData.Expression);
            mockPatientSet.As<IQueryable<Patient>>().Setup(m => m.ElementType).Returns(_patientData.ElementType);
            mockPatientSet.As<IQueryable<Patient>>().Setup(m => m.GetEnumerator()).Returns(() => _patientData.GetEnumerator());

            Mock<HospitalSystemContext> mockContext = new Mock<HospitalSystemContext>();
            mockContext.Setup(m => m.Set<Doctor>()).Returns(mockDoctorSet.Object);
            mockContext.Setup(m => m.Set<Patient>()).Returns(mockPatientSet.Object);

            _doctorRepository = new HospitalSystemUnitOfWork(mockContext.Object).DoctorRepository;
        }

        IQueryable<Doctor> _doctorData;
        IQueryable<Patient> _patientData;
        DoctorRepository _doctorRepository;
    }
}
