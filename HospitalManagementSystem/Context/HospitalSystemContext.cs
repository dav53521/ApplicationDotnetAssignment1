using ApplicationDotnetAssignment1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ApplicationDotnetAssignment1.Contexts
{
    public class HospitalSystemContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DAVIDTHINKPAD; Database=HospitalManagementSystem; User Id=David; Password=test; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable(user => user.HasCheckConstraint("UR_User_OnlyCanHaveApprovedRole", "Role IN ('Admin', 'Doctor', 'Patient')"));

            //This is being used to seed the data by using the passed in model builder to insert the passed in models into the DB during a migration so that the database starts off with data after a migration occurs
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "David",
                    Email = "David@snailmail.com",
                    PhoneNumber = "0411111111",
                    Address = "20 This is a real street, Sydney, NSW",
                    Password = "test",
                    Role = "Admin"
                },
                new User
                {
                    Id = 2,
                    Name = "Ben",
                    Email = "Ben@carrierpigeonmail.com",
                    PhoneNumber = "0411111110",
                    Address = "10 This is a real street, Sydney, NSW",
                    Password = "ben",
                    Role = "Doctor"
                },
                new User
                {
                    Id = 3,
                    Name = "Jack",
                    Email = "Jack@owlmail.com",
                    PhoneNumber = "0411111100",
                    Address = "2 This is a real street, Sydney, NSW",
                    Password = "password",
                    Role = "Patient"
                });
        }
    }
}
