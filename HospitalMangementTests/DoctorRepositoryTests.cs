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

            Mock<DbSet<Doctor>> mockDoctorSet = new Mock<DbSet<Doctor>>();
            mockDoctorSet.As<IQueryable<Doctor>>().Setup(m => m.Provider).Returns(_doctorData.Provider);
            mockDoctorSet.As<IQueryable<Doctor>>().Setup(m => m.Expression).Returns(_doctorData.Expression);
            mockDoctorSet.As<IQueryable<Doctor>>().Setup(m => m.ElementType).Returns(_doctorData.ElementType);
            mockDoctorSet.As<IQueryable<Doctor>>().Setup(m => m.GetEnumerator()).Returns(() => _doctorData.GetEnumerator());

            Mock<HospitalSystemContext> mockContext = new Mock<HospitalSystemContext>();

            _doctorRepository = new HospitalSystemUnitOfWork(mockContext.Object).DoctorRepository;
        }

        IQueryable<Doctor> _doctorData;
        DoctorRepository _doctorRepository;
    }
}
