using ApplicationDotnetAssignment1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ApplicationDotnetAssignment1.Contexts
{
    public class HospitalSystemContext : DbContext
    {
        public DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DAVIDTHINKPAD; Database=HospitalManagementSystem; User Id=David; Password=test; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //This is being used to seed the data by using the passed in model builder to insert the passed in models into the DB during a migration so that the database starts off with data after a migration occurs
            modelBuilder.Entity<Users>().HasData(
                new Users
                {
                    Id = 1,
                    Name = "David",
                    Email = "David@snailmail.com",
                    PhoneNumber = "0411111111",
                    Address = "20 This is a real street, Sydney, NSW",
                    Password = "test",
                    Role = "Admin"
                });
        }
    }
}
