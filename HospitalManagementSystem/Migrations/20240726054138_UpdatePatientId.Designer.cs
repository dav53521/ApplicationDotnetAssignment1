﻿// <auto-generated />
using System;
using ApplicationDotnetAssignment1.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApplicationDotnetAssignment1.Migrations
{
    [DbContext(typeof(HospitalSystemContext))]
    [Migration("20240726054138_UpdatePatientId")]
    partial class UpdatePatientId
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApplicationDotnetAssignment1.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            Id = 10000,
                            Address = "21 Test Test",
                            Email = "Test@Test.com",
                            Name = "David Sorrell",
                            Password = "123",
                            PhoneNumber = "0411111111"
                        });
                });

            modelBuilder.Entity("ApplicationDotnetAssignment1.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            Id = 10000,
                            Description = "Cold",
                            DoctorId = 11000,
                            PatientId = 20000
                        },
                        new
                        {
                            Id = 10001,
                            Description = "Test",
                            DoctorId = 11000,
                            PatientId = 20002
                        });
                });

            modelBuilder.Entity("ApplicationDotnetAssignment1.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            Id = 11000,
                            Address = "12 A real street ave",
                            Email = "Test@email.com",
                            Name = "John Deer",
                            Password = "test",
                            PhoneNumber = "0411111111"
                        });
                });

            modelBuilder.Entity("ApplicationDotnetAssignment1.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("AssignedDoctorId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("AssignedDoctorId");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            Id = 20000,
                            Address = "10 A real street ave",
                            AssignedDoctorId = 11000,
                            Email = "Test@email.com",
                            Name = "Jill Deer",
                            Password = "123",
                            PhoneNumber = "0411111111"
                        },
                        new
                        {
                            Id = 20001,
                            Address = "11 A real street ave",
                            Email = "Test@email.com",
                            Name = "Jane Deer",
                            Password = "test",
                            PhoneNumber = "0411111111"
                        },
                        new
                        {
                            Id = 20002,
                            Address = "11 A real street ave",
                            AssignedDoctorId = 11000,
                            Email = "Test@email.com",
                            Name = "Person Person",
                            Password = "123",
                            PhoneNumber = "0411111111"
                        },
                        new
                        {
                            Id = 20003,
                            Address = "11 A real street ave",
                            Email = "david2017au@gmail.com",
                            Name = "David Sorrell",
                            Password = "123",
                            PhoneNumber = "0411111111"
                        });
                });

            modelBuilder.Entity("ApplicationDotnetAssignment1.Models.Appointment", b =>
                {
                    b.HasOne("ApplicationDotnetAssignment1.Models.Doctor", "Doctor")
                        .WithMany("AssignedAppointments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationDotnetAssignment1.Models.Patient", "Patient")
                        .WithMany("BookedAppointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("ApplicationDotnetAssignment1.Models.Patient", b =>
                {
                    b.HasOne("ApplicationDotnetAssignment1.Models.Doctor", "AssignedDoctor")
                        .WithMany("Patients")
                        .HasForeignKey("AssignedDoctorId");

                    b.Navigation("AssignedDoctor");
                });

            modelBuilder.Entity("ApplicationDotnetAssignment1.Models.Doctor", b =>
                {
                    b.Navigation("AssignedAppointments");

                    b.Navigation("Patients");
                });

            modelBuilder.Entity("ApplicationDotnetAssignment1.Models.Patient", b =>
                {
                    b.Navigation("BookedAppointments");
                });
#pragma warning restore 612, 618
        }
    }
}
