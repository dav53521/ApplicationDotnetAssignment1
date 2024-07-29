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
                    Name = "Jack Doe",
                    Password = "hello",
                    PhoneNumber = "0491570151",
                    Email = "Jack@PigeonMail.com",
                    Address = "12 Place Street Sydney NSW"
                },
                new Doctor
                {
                    Id = 10004,
                    Name = "Jack Doe",
                    Password = "hello",
                    PhoneNumber = "0491570151",
                    Email = "Jack@PigeonMail.com",
                    Address = "12 Place Street Sydney NSW"
                },
                new Doctor
                {
                    Id = 10005,
                    Name = "Jack Doe",
                    Password = "hello",
                    PhoneNumber = "0491570151",
                    Email = "Jack@PigeonMail.com",
                    Address = "12 Place Street Sydney NSW"
                }, new Doctor
                {
                    Id = 10006,
                    Name = "Jack Doe",
                    Password = "hello",
                    PhoneNumber = "0491570151",
                    Email = "Jack@PigeonMail.com",
                    Address = "12 Place Street Sydney NSW"
                },
                new Doctor
                {
                    Id = 10007,
                    Name = "Jack Doe",
                    Password = "hello",
                    PhoneNumber = "0491570151",
                    Email = "Jack@PigeonMail.com",
                    Address = "12 Place Street Sydney NSW"
                },
                new Doctor
                {
                    Id = 10008,
                    Name = "Jack Doe",
                    Password = "hello",
                    PhoneNumber = "0491570151",
                    Email = "Jack@PigeonMail.com",
                    Address = "12 Place Street Sydney NSW"
                },
                new Doctor
                {
                    Id = 10009,
                    Name = "Jack Doe",
                    Password = "hello",
                    PhoneNumber = "0491570151",
                    Email = "Jack@PigeonMail.com",
                    Address = "12 Place Street Sydney NSW"
                }
            );

            modelBuilder.Entity<Patient>().HasData(
                new Patient
                {
                    Id = 20000,
                    Name = "Jill Deer",
                    Password = "123",
                    PhoneNumber = "0491570157",
                    Email = "Test@email.com",
                    Address = "10 place street Sydney NSW",
                    AssignedDoctorId = 10000
                },
                new Patient
                {
                    Id = 20001,
                    Name = "Jane Deer",
                    Password = "test",
                    PhoneNumber = "0491570006",
                    Email = "Test@email.com",
                    Address = "11 real street Melbourne VIC",
                },
                new Patient
                {
                    Id = 20002,
                    Name = "Person Person",
                    Password = "123",
                    PhoneNumber = "0491570158",
                    Email = "Test@email.com",
                    Address = "10 Nowhere Drive Sydney NSW",
                    AssignedDoctorId = 10002
                },
                new Patient
                {
                    Id = 20003,
                    Name = "David Sorrell",
                    Password = "123",
                    PhoneNumber = "0491570159",
                    Email = "david2017au@gmail.com",
                    Address = "11 A real street ave Sydney NSW",
                },
                new Patient
                {
                    Id = 20004,
                    Name = "David Sorrell",
                    Password = "123",
                    PhoneNumber = "0491570159",
                    Email = "david2017au@gmail.com",
                    Address = "11 A real street ave Sydney NSW",
                },
                new Patient
                {
                    Id = 20005,
                    Name = "David Sorrell",
                    Password = "123",
                    PhoneNumber = "0491570159",
                    Email = "david2017au@gmail.com",
                    Address = "11 A real street ave Sydney NSW",
                }, new Patient
                {
                    Id = 20006,
                    Name = "David Sorrell",
                    Password = "123",
                    PhoneNumber = "0491570159",
                    Email = "david2017au@gmail.com",
                    Address = "11 A real street ave Sydney NSW",
                },
                new Patient
                {
                    Id = 20007,
                    Name = "David Sorrell",
                    Password = "123",
                    PhoneNumber = "0491570159",
                    Email = "david2017au@gmail.com",
                    Address = "11 A real street ave Sydney NSW",
                },
                new Patient
                {
                    Id = 20008,
                    Name = "David Sorrell",
                    Password = "123",
                    PhoneNumber = "0491570159",
                    Email = "david2017au@gmail.com",
                    Address = "11 A real street ave Sydney NSW",
                },
                new Patient
                {
                    Id = 20009,
                    Name = "David Sorrell",
                    Password = "123",
                    PhoneNumber = "0491570159",
                    Email = "david2017au@gmail.com",
                    Address = "11 A real street ave Sydney NSW",
                }
            );

            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Id = 30000,
                    Name = "David Sorrell",
                    Email = "Test@Test.com",
                    PhoneNumber = "0491570110",
                    Password = "123",
                    Address = "21 Test Test Drive Sydney NSW"
                },
                new Admin
                {
                    Id = 30001,
                    Name = "David Person",
                    Email = "Test@Test.com",
                    PhoneNumber = "0491570110",
                    Password = "test",
                    Address = "21 Test Test Drive Sydney NSW"
                },
                new Admin
                {
                    Id = 30002,
                    Name = "David Person",
                    Email = "Person@gmail2.com",
                    PhoneNumber = "0491570110",
                    Password = "321",
                    Address = "21 Test Test Drive Sydney NSW"
                },
                new Admin
                {
                    Id = 30003,
                    Name = "David Person",
                    Email = "Person@gmail2.com",
                    PhoneNumber = "0491570110",
                    Password = "321",
                    Address = "21 Test Test Drive Sydney NSW"
                },
                new Admin
                {
                    Id = 30004,
                    Name = "David Person",
                    Email = "Person@gmail2.com",
                    PhoneNumber = "0491570110",
                    Password = "321",
                    Address = "21 Test Test Drive Sydney NSW"
                },
                new Admin
                {
                    Id = 30005,
                    Name = "David Person",
                    Email = "Person@gmail2.com",
                    PhoneNumber = "0491570110",
                    Password = "321",
                    Address = "21 Test Test Drive Sydney NSW"
                },
                new Admin
                {
                    Id = 30006,
                    Name = "David Person",
                    Email = "Person@gmail2.com",
                    PhoneNumber = "0491570110",
                    Password = "321",
                    Address = "21 Test Test Drive Sydney NSW"
                },
                new Admin
                {
                    Id = 30007,
                    Name = "David Person",
                    Email = "Person@gmail2.com",
                    PhoneNumber = "0491570110",
                    Password = "321",
                    Address = "21 Test Test Drive Sydney NSW"
                },
                new Admin
                {
                    Id = 30008,
                    Name = "David Person",
                    Email = "Person@gmail2.com",
                    PhoneNumber = "0491570110",
                    Password = "321",
                    Address = "21 Test Test Drive Sydney NSW"
                },
                new Admin
                {
                    Id = 30009,
                    Name = "David Person",
                    Email = "Person@gmail2.com",
                    PhoneNumber = "0491570110",
                    Password = "321",
                    Address = "21 Test Test Drive Sydney NSW"
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
                    PatientId = 20002,
                    DoctorId = 10002,
                    Description = "Covid-19"
                },
                new Appointment
                {
                    Id = 10002,
                    PatientId = 20002,
                    DoctorId = 10002,
                    Description = "A cough"
                }
            );
        }
    }
}