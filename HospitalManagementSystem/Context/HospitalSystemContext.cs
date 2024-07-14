﻿using ApplicationDotnetAssignment1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ApplicationDotnetAssignment1.Contexts
{
    public class HospitalSystemContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public HospitalSystemContext()
        {
            //Disabiling lazy loading so that it is no longer needed to use the "include" function when trying to do something like getting the patients assigned to a doctor as it means that it's possible to query all users without having to check if it's a certain user type which allows for more succinct queries
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DAVIDTHINKPAD; Database=HospitalManagementSystem; User Id=David; Password=test; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasMany(d => d.Patients).WithOne(p => p.AssignedDoctor).HasForeignKey(p => p.AssignedDoctorId).IsRequired(false);
            modelBuilder.Entity<Patient>().HasOne(p => p.AssignedDoctor).WithMany(d => d.Patients).HasForeignKey(p => p.AssignedDoctorId).IsRequired(false);

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = 11,
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
                    Id = 21,
                    Name = "Jill Deer",
                    Password = "123",
                    PhoneNumber = "0411111111",
                    Email = "Test@email.com",
                    Address = "10 A real street ave",
                    AssignedDoctorId = 11
                },
                new Patient
                {
                    Id = 22,
                    Name = "Jane Deer",
                    Password = "Jane",
                    PhoneNumber = "0411111111",
                    Email = "Test@email.com",
                    Address = "11 A real street ave",
                }
            );

            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Id = 1,
                    Name = "David Sorrell",
                    Password = "Password"
                }
            );
        }
    }
}
