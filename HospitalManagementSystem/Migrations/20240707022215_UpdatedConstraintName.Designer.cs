﻿// <auto-generated />
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
    [Migration("20240707022215_UpdatedConstraintName")]
    partial class UpdatedConstraintName
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApplicationDotnetAssignment1.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users", t =>
                        {
                            t.HasCheckConstraint("UR_User_OnlyCanHaveApprovedRole", "Role IN ('Admin', 'Doctor', 'Patient')");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "20 This is a real street, Sydney, NSW",
                            Email = "David@snailmail.com",
                            Name = "David",
                            Password = "test",
                            PhoneNumber = "0411111111",
                            Role = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Address = "10 This is a real street, Sydney, NSW",
                            Email = "Ben@carrierpigeonmail.com",
                            Name = "Ben",
                            Password = "ben",
                            PhoneNumber = "0411111110",
                            Role = "Doctor"
                        },
                        new
                        {
                            Id = 3,
                            Address = "2 This is a real street, Sydney, NSW",
                            Email = "Jack@owlmail.com",
                            Name = "Jack",
                            Password = "password",
                            PhoneNumber = "0411111100",
                            Role = "Patient"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
