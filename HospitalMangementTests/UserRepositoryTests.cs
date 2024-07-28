using ApplicationDotnetAssignment1.Contexts;
using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.Repositories;
using ApplicationDotnetAssignment1.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace HospitalMangementTests
{
    public class UserRepositoryTests
    {
        [Test]
        public void TestUserRepositoryCanGetAllUsersInContext()
        {
            List<User> result = _userRepository.GetAllUsers();

            Assert.That(result.Count(), Is.EqualTo(6));
            Assert.That(result, Is.SupersetOf(_doctorData));
            Assert.That(result, Is.SupersetOf(_adminData));
            Assert.That(result, Is.SupersetOf(_patientData));
        }

        [Test]
        public void TestUserRepositoryCannotGetUsersThatAreNotInContext()
        {
            Doctor nonDbUser = new Doctor
            {
                Id = 10003,
                Name = "Test test",
                Email = "test@test.com",
                Password = "123",
                Address = "22 test sydney nsw 2000",
                PhoneNumber = "1234567890",
            };

            List<User> result = _userRepository.GetAllUsers();

            Assert.That(result, Does.Not.Contain(nonDbUser));
        }

        [Test]
        public void TestUserRepositoryCanGetUsersById()
        {
            User? foundDoctor = _userRepository.GetUserById(10000);
            User? foundPatient = _userRepository.GetUserById(20000);
            User? foundAdmin = _userRepository.GetUserById(30000);

            AssertThatUserCredentalsAreCorrect(foundDoctor, 10000, "Test1", "1231", "10000@test.com", "20 test sydney nsw 2000", "1234567890");
            AssertThatUserCredentalsAreCorrect(foundPatient, 20000, "Test3", "1233", "20000@test.com", "20 test sydney nsw 2000", "1234567892");
            AssertThatUserCredentalsAreCorrect(foundAdmin, 30000, "Test5", "1234", "30000@test.com", "20 test sydney nsw 2000", "1234567894");
        }

        [Test]
        public void TestUserRepositoryCannotGetUsersByInvalidId()
        {
            User? invalidUser1 = _userRepository.GetUserById(10003);
            User? invalidUser2 = _userRepository.GetUserById(20003);
            User? invalidUser3 = _userRepository.GetUserById(30003);

            Assert.That(invalidUser1, Is.Null);
            Assert.That(invalidUser2, Is.Null);
            Assert.That(invalidUser3 , Is.Null);
        }

        [Test]
        public void TestUserRepositoryCanFindUsersByPredicate()
        {
            List<User> actual = _userRepository.FindUsers(u => u.Address == "20 test sydney nsw 2000");

            Assert.That(actual.Count, Is.EqualTo(3));
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
                },
                new Patient
                {
                    Id = 20001,
                    Name = "Test4",
                    Email = "20001@test.com",
                    Password = "123",
                    Address = "21 test sydney nsw 2000",
                    PhoneNumber = "1234567893",
                }
            }.AsQueryable();

            _adminData = new List<Admin>
            {
                new Admin
                {
                    Id = 30000,
                    Password = "1234",
                    Name = "Test5",
                    Email = "30000@test.com",
                    Address = "20 test sydney nsw 2000",
                    PhoneNumber = "1234567894",

                },
                new Admin
                {
                    Id = 30001,
                    Password = "1235",
                    Name = "Test6",
                    Email = "10001@test.com",
                    Address = "21 test sydney nsw 2000",
                    PhoneNumber = "1234567895",
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

            Mock<DbSet<Admin>> mockAdminSet = new Mock<DbSet<Admin>>();
            mockAdminSet.As<IQueryable<Admin>>().Setup(m => m.Provider).Returns(_adminData.Provider);
            mockAdminSet.As<IQueryable<Admin>>().Setup(m => m.Expression).Returns(_adminData.Expression);
            mockAdminSet.As<IQueryable<Admin>>().Setup(m => m.ElementType).Returns(_adminData.ElementType);
            mockAdminSet.As<IQueryable<Admin>>().Setup(m => m.GetEnumerator()).Returns(() => _adminData.GetEnumerator());

            Mock<HospitalSystemContext> mockContext = new Mock<HospitalSystemContext>();
            mockContext.SetupGet(m => m.Doctors).Returns(mockDoctorSet.Object);
            mockContext.SetupGet(m => m.Patients).Returns(mockPatientSet.Object);
            mockContext.SetupGet(m => m.Admins).Returns(mockAdminSet.Object);

            _userRepository = new HospitalSystemUnitOfWork(mockContext.Object).UserRepository;
        }

        IQueryable<Doctor> _doctorData;
        IQueryable<Patient> _patientData;
        IQueryable<Admin> _adminData;

        UserRepository _userRepository;
    }
}
