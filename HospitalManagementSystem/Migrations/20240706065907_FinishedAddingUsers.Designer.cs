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
    [Migration("20240706065907_FinishedAddingUsers")]
    partial class FinishedAddingUsers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApplicationDotnetAssignment1.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AssociatedUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssociatedUserId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("ApplicationDotnetAssignment1.Models.Interfaces.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("ApplicationDotnetAssignment1.Models.Paitent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Paitents");
                });

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

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "20 definitely a real address, Sydney, NSW",
                            Email = "David@SnailMail.com",
                            Name = "David",
                            Password = "test",
                            PhoneNumber = "+61046550226"
                        });
                });

            modelBuilder.Entity("ApplicationDotnetAssignment1.Models.Doctor", b =>
                {
                    b.HasOne("ApplicationDotnetAssignment1.Models.User", "AssociatedUser")
                        .WithMany()
                        .HasForeignKey("AssociatedUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssociatedUser");
                });
#pragma warning restore 612, 618
        }
    }
}
