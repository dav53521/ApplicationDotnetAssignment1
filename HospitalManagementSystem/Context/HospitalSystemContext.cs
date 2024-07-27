﻿using ApplicationDotnetAssignment1.Models;
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
            modelBuilder.Entity<Appointment>()
            .Property(a => a.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Doctor>().HasMany(d => d.Patients).WithOne(p => p.AssignedDoctor).HasForeignKey(p => p.AssignedDoctorId).IsRequired(false);
            modelBuilder.Entity<Patient>().HasOne(p => p.AssignedDoctor).WithMany(d => d.Patients).HasForeignKey(p => p.AssignedDoctorId).IsRequired(false);
            modelBuilder.Entity<Appointment>().HasOne(a => a.Patient).WithMany(p => p.BookedAppointments).HasForeignKey(p => p.PatientId).IsRequired(true);
            modelBuilder.Entity<Appointment>().HasOne(a => a.Doctor).WithMany(p => p.AssignedAppointments).HasForeignKey(p => p.DoctorId).IsRequired(true);

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = 11000,
                    Name = "John Deer",
                    Password = "test",
                    PhoneNumber = "0411111111",
                    Email = "Test@email.com",
                    Address = "12 A real street ave"
                }
            );

            modelBuilder.Entity<Patient>().HasData(
                new Patient
                {
                    Id = 20000,
                    Name = "Jill Deer",
                    Password = "123",
                    PhoneNumber = "0411111111",
                    Email = "Test@email.com",
                    Address = "10 A real street ave",
                    AssignedDoctorId = 11000
                },
                new Patient
                {
                    Id = 20001,
                    Name = "Jane Deer",
                    Password = "test",
                    PhoneNumber = "0411111111",
                    Email = "Test@email.com",
                    Address = "11 A real street ave",
                },
                new Patient
                {
                    Id = 20002,
                    Name = "Person Person",
                    Password = "123",
                    PhoneNumber = "0411111111",
                    Email = "Test@email.com",
                    Address = "11 A real street ave",
                    AssignedDoctorId = 11000
                },
                new Patient
                {
                    Id = 20003,
                    Name = "David Sorrell",
                    Password = "123",
                    PhoneNumber = "0411111111",
                    Email = "david2017au@gmail.com",
                    Address = "11 A real street ave",
                }
            );

            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Id = 10000,
                    Name = "David Sorrell",
                    Email = "Test@Test.com",
                    PhoneNumber = "0411111111",
                    Password = "123",
                    Address = "21 Test Test"
                }
            );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 10000,
                    PatientId = 20000,
                    DoctorId = 11000,
                    Description = "Cold"
                },
                new Appointment
                {
                    Id = 10001,
                    PatientId = 20002,
                    DoctorId = 11000,
                    Description = "Test"
                }
            );
        }
    }
}