﻿// <auto-generated />
using System;
using EmployeeRequestTrackerAPI.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeRequestTrackerAPI.Migrations
{
    [DbContext(typeof(RequestTrackerContext))]
    partial class RequestTrackerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EmployeeRequestTrackerAPI.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 101,
                            DateOfBirth = new DateTime(2000, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "",
                            Name = "Ramu",
                            Phone = "9876543321",
                            Role = "Admin"
                        },
                        new
                        {
                            Id = 102,
                            DateOfBirth = new DateTime(2002, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "",
                            Name = "Somu",
                            Phone = "9988776655",
                            Role = "User"
                        },
                        new
                        {
                            Id = 103,
                            DateOfBirth = new DateTime(2001, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "",
                            Name = "Ravi",
                            Phone = "9876543210",
                            Role = "User"
                        },
                        new
                        {
                            Id = 104,
                            DateOfBirth = new DateTime(2003, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "",
                            Name = "Raju",
                            Phone = "9988776655",
                            Role = "User"
                        });
                });

            modelBuilder.Entity("EmployeeRequestTrackerAPI.Models.Request", b =>
                {
                    b.Property<int>("RequestNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequestNumber"), 1L, 1);

                    b.Property<DateTime?>("CloseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RaisedByEmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RequestMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestStatus")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RequestNumber");

                    b.HasIndex("RaisedByEmployeeId");

                    b.ToTable("Request");
                });

            modelBuilder.Entity("EmployeeRequestTrackerAPI.Models.User", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordHashKey")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EmployeeRequestTrackerAPI.Models.Request", b =>
                {
                    b.HasOne("EmployeeRequestTrackerAPI.Models.Employee", "RaisedByEmployee")
                        .WithMany("Requests")
                        .HasForeignKey("RaisedByEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RaisedByEmployee");
                });

            modelBuilder.Entity("EmployeeRequestTrackerAPI.Models.User", b =>
                {
                    b.HasOne("EmployeeRequestTrackerAPI.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("EmployeeRequestTrackerAPI.Models.Employee", b =>
                {
                    b.Navigation("Requests");
                });
#pragma warning restore 612, 618
        }
    }
}