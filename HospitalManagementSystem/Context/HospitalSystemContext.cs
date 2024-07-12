using ApplicationDotnetAssignment1.Models;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DAVIDTHINKPAD; Database=HospitalManagementSystem; User Id=David; Password=test; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasMany(d => d.Patients).WithOne(p => p.AssignedDoctor).HasForeignKey(p => p.AssignedDoctorId).IsRequired(false);
            modelBuilder.Entity<Patient>().HasOne(p => p.AssignedDoctor).WithMany(d => d.Patients).HasForeignKey(p => p.AssignedDoctorId).IsRequired(false);
        }
    }
}
