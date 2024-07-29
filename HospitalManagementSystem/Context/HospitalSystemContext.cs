using ApplicationDotnetAssignment1.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationDotnetAssignment1.Contexts
{
    public class HospitalSystemContext : DbContext
    {
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Setting the connection string so that it uses my server with the correct database and the correct login to access the database so it is possible to read and update
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=DAVIDTHINKPAD; Database=HospitalManagementSystem; User Id=David; Password=test; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasMany(d => d.Patients).WithOne(p => p.AssignedDoctor).HasForeignKey(p => p.AssignedDoctorId).IsRequired(false);
            modelBuilder.Entity<Patient>().HasOne(p => p.AssignedDoctor).WithMany(d => d.Patients).HasForeignKey(p => p.AssignedDoctorId).IsRequired(false);
            modelBuilder.Entity<Appointment>().HasOne(a => a.Patient).WithMany(p => p.BookedAppointments).HasForeignKey(p => p.PatientId).IsRequired(true);
            modelBuilder.Entity<Appointment>().HasOne(a => a.Doctor).WithMany(p => p.AssignedAppointments).HasForeignKey(p => p.DoctorId).IsRequired(true);

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = 10000,
                    Name = "John Deer",
                    Password = "test",
                    PhoneNumber = "0491570156",
                    Email = "Test@email.com",
                    Address = "12 Ultimo Road Sydney NSW"
                },
                new Doctor
                {
                    Id = 10001,
                    Name = "Mr Doctor",
                    Password = "Password",
                    PhoneNumber = "0491570158",
                    Email = "Doctor@snaimail.com",
                    Address = "10 Ultimo Road Sydney NSW"
                },
                new Doctor
                {
                    Id = 10002,
                    Name = "Jack Doe",
                    Password = "hello",
                    PhoneNumber = "0491570151",
                    Email = "Jack@PigeonMail.com",
                    Address = "12 Place Street Sydney NSW"
                },
                new Doctor
                {
                    Id = 10003,
                    Name = "Jane Dane",
                    Password = "123Jane",
                    PhoneNumber = "0491570152",
                    Email = "Jane@fakegmail.com",
                    Address = "14 100% Real Street Sydney NSW"
                },
                new Doctor
                {
                    Id = 10004,
                    Name = "Jack Test",
                    Password = "JackTest",
                    PhoneNumber = "0491570153",
                    Email = "Jack@PigeonSnailMail.com",
                    Address = "100 Place Street Sydney NSW"
                },
                new Doctor
                {
                    Id = 10005,
                    Name = "Florence Padilla",
                    Password = "hellohello",
                    PhoneNumber = "0491570154",
                    Email = "Florence@PigeonMail.com",
                    Address = "2 Somewhere Street Sydney NSW"
                }, new Doctor
                {
                    Id = 10006,
                    Name = "Riya Jordan",
                    Password = "JordanRules",
                    PhoneNumber = "0491570155",
                    Email = "Jordan@PigeonMail.com",
                    Address = "10 A Real Street Sydney NSW"
                },
                new Doctor
                {
                    Id = 10007,
                    Name = "Dan Peters",
                    Password = "DanSaysHello",
                    PhoneNumber = "0491570156",
                    Email = "Dan@PigeonMail.com",
                    Address = "13 Place Street Sydney NSW"
                },
                new Doctor
                {
                    Id = 10008,
                    Name = "Jazmine Church",
                    Password = "JazmineJazmine",
                    PhoneNumber = "0491570157",
                    Email = "Church@PigeonMail.com",
                    Address = "14 Place Street Sydney NSW"
                },
                new Doctor
                {
                    Id = 10009,
                    Name = "Victoria Mckee",
                    Password = "Mckee",
                    PhoneNumber = "0491570158",
                    Email = "Victoria@PigeonMail.com",
                    Address = "15 Place Street Sydney NSW"
                }
            );

            modelBuilder.Entity<Patient>().HasData(
                new Patient
                {
                    Id = 20000,
                    Name = "Jill Deer",
                    Password = "DeerIsMyName",
                    PhoneNumber = "0491570157",
                    Email = "Test@email.com",
                    Address = "10 Street Street Sydney NSW",
                    AssignedDoctorId = 10000
                },
                new Patient
                {
                    Id = 20001,
                    Name = "Jane Deer",
                    Password = "Anonymous",
                    PhoneNumber = "0491570006",
                    Email = "Test@email.com",
                    Address = "11 Real Street Melbourne VIC",
                },
                new Patient
                {
                    Id = 20002,
                    Name = "Person Person",
                    Password = "Person",
                    PhoneNumber = "0491570158",
                    Email = "Test@email.com",
                    Address = "10 Nowhere Drive Sydney NSW",
                    AssignedDoctorId = 10002
                },
                new Patient
                {
                    Id = 20003,
                    Name = "David Sorrell",
                    Password = "MyRealPassword",
                    PhoneNumber = "0491570159",
                    Email = "david2017au@gmail.com",
                    Address = "11 Street Street Sydney NSW",
                },
                new Patient
                {
                    Id = 20004,
                    Name = "Vinnie Goodwin",
                    Password = "VinnieIsGood",
                    PhoneNumber = "0491570159",
                    Email = "Goodwin@gmail2.com",
                    Address = "12 Street Street Sydney NSW",
                    AssignedDoctorId = 10004
                },
                new Patient
                {
                    Id = 20005,
                    Name = "Subhan Walls",
                    Password = "WallsRule",
                    PhoneNumber = "0491570159",
                    Email = "Walls@gmail2.com",
                    Address = "13 Street Street Sydney NSW",
                }, new Patient
                {
                    Id = 20006,
                    Name = "Lillie Sears",
                    Password = "Sears",
                    PhoneNumber = "0491570159",
                    Email = "Sears@gmail2.com",
                    Address = "14 Street Street Sydney NSW",
                    AssignedDoctorId = 10006
                },
                new Patient
                {
                    Id = 20007,
                    Name = "Connie Clay",
                    Password = "ClayIsTasty",
                    PhoneNumber = "0491570159",
                    Email = "Clay@gmail2.com",
                    Address = "15 Street Street Sydney NSW",
                },
                new Patient
                {
                    Id = 20008,
                    Name = "Diana Petty",
                    Password = "Petty",
                    PhoneNumber = "0491570159",
                    Email = "Diana@gmail2.com",
                    Address = "16 Street Street Sydney NSW",
                    AssignedDoctorId = 10008
                },
                new Patient
                {
                    Id = 20009,
                    Name = "Sam Santana",
                    Password = "InspectorSam",
                    PhoneNumber = "0491570159",
                    Email = "Santana@gmail2.com",
                    Address = "17 Street Street Sydney NSW",
                }
            );

            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Id = 30000,
                    Name = "David Sorrell",
                    Email = "David@Test.com",
                    PhoneNumber = "0491570110",
                    Password = "123",
                    Address = "21 Test Test Drive Sydney NSW"
                },
                new Admin
                {
                    Id = 30001,
                    Name = "David Person",
                    Email = "Person@Test.com",
                    PhoneNumber = "0491570110",
                    Password = "Person",
                    Address = "22 Test Test Drive Sydney NSW"
                },
                new Admin
                {
                    Id = 30002,
                    Name = "Norma Rubio",
                    Email = "Rubio@gmail2.com",
                    PhoneNumber = "0491570110",
                    Password = "FInTheChat",
                    Address = "23 Test Test Drive Sydney NSW"
                },
                new Admin
                {
                    Id = 30003,
                    Name = "Ifan Norton",
                    Email = "Ifan@gmail2.com",
                    PhoneNumber = "0491570110",
                    Password = "NortonAntiVirus",
                    Address = "24 Test Test Drive Sydney NSW"
                },
                new Admin
                {
                    Id = 30004,
                    Name = "Sapphire Shaw",
                    Email = "Shaw@gmail2.com",
                    PhoneNumber = "0491570110",
                    Password = "GrimShaw",
                    Address = "25 Test Test Drive Sydney NSW"
                },
                new Admin
                {
                    Id = 30005,
                    Name = "Rick Sanchez",
                    Email = "Rick@gmail2.com",
                    PhoneNumber = "0491570110",
                    Password = "IAmARickAndMortyReference",
                    Address = "26 Test Test Drive Sydney NSW"
                },
                new Admin
                {
                    Id = 30006,
                    Name = "Eleanor Mcclain",
                    Email = "Mcclain@gmail2.com",
                    PhoneNumber = "0491570110",
                    Password = "McclainIsTheName",
                    Address = "27 Test Test Drive Sydney NSW"
                },
                new Admin
                {
                    Id = 30007,
                    Name = "Grace O'Connor",
                    Email = "Grace@gmail2.com",
                    PhoneNumber = "0491570110",
                    Password = "GraceExists",
                    Address = "28 Test Test Drive Sydney NSW"
                },
                new Admin
                {
                    Id = 30008,
                    Name = "Evie Ward",
                    Email = "Ward@gmail2.com",
                    PhoneNumber = "0491570110",
                    Password = "HospitalWard",
                    Address = "29 Test Test Drive Sydney NSW"
                },
                new Admin
                {
                    Id = 30009,
                    Name = "Lorraine Stokes",
                    Email = "Stokes@gmail2.com",
                    PhoneNumber = "0491570110",
                    Password = "StokesExists",
                    Address = "30 Test Test Drive Sydney NSW"
                }
            );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 10000,
                    PatientId = 20000,
                    DoctorId = 10000,
                    Description = "Cold"
                },
                new Appointment
                {
                    Id = 10001,
                    PatientId = 20000,
                    DoctorId = 10000,
                    Description = "Something I swear"
                },
                new Appointment
                {
                    Id = 10002,
                    PatientId = 20002,
                    DoctorId = 10002,
                    Description = "Covid-19"
                },
                new Appointment
                {
                    Id = 10003,
                    PatientId = 20002,
                    DoctorId = 10002,
                    Description = "A cough"
                },
                new Appointment
                {
                    Id = 10004,
                    PatientId = 20004,
                    DoctorId = 10004,
                    Description = "Just because"
                },
                new Appointment
                {
                    Id = 10005,
                    PatientId = 20004,
                    DoctorId = 10004,
                    Description = "Wanted Email"
                },
                new Appointment
                {
                    Id = 10006,
                    PatientId = 20006,
                    DoctorId = 10006,
                    Description = "I was lonely"
                },
                 new Appointment
                 {
                     Id = 10007,
                     PatientId = 20006,
                     DoctorId = 10006,
                     Description = "Dying"
                 },
                 new Appointment
                 {
                     Id = 10008,
                     PatientId = 20008,
                     DoctorId = 10008,
                     Description = "yearly checkup"
                 },
                 new Appointment
                 {
                     Id = 10009,
                     PatientId = 20008,
                     DoctorId = 10008,
                     Description = "Because Why not"
                 }
            );
        }
    }
}