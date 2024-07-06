using ApplicationDotnetAssignment1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ApplicationDotnetAssignment1.Contexts
{
    public class HospitalUserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DAVIDTHINKPAD; Database=HospitalManagementSystem; User Id=David; Password=test; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //This is being used to seed the data by using the passed in model builder to insert the passed in models into the DB during a migration so that the database starts off with data after a migration occurs
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "David",
                    Email = "David@SnailMail.com",
                    PhoneNumber = "+61046550226",
                    Address = "20 definitely a real address, Sydney, NSW",
                    Password = "test"
                });
        }
    }
}
