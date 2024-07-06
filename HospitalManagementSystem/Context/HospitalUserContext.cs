using ApplicationDotnetAssignment1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ApplicationDotnetAssignment1.Contexts
{
    public class HospitalUserContext : DbContext
    {
        public DbSet<LoginDetails> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Paitent> Paitents { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DAVIDTHINKPAD; Database=HospitalManagementSystem; User Id=David; Password=test; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //This is being used to seed the data by using the passed in model builder to insert the passed in models into the DB during a migration so that the database starts off with data after a migration occurs
            modelBuilder.Entity<LoginDetails>().HasData(
                new LoginDetails
                {
                    Id = 1,
                    Password = "test",
                    Role = "Admin"
                });
        }
    }
}
