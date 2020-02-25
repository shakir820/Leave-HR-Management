﻿// <auto-generated />
using System;
using Leave_HR_Management.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Leave_HR_Management.Migrations
{
    [DbContext(typeof(AbcContext))]
    partial class AbcContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("Leave_HR_Management.Models.Department", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Leave_HR_Management.Models.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EmployeeRole")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Gender")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<long?>("PrimaryDepartmentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PrimaryDepartmentId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Leave_HR_Management.Models.LeaveApprover", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("DepartmentId")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("LeaveApprovers");
                });

            modelBuilder.Entity("Leave_HR_Management.Models.Department", b =>
                {
                    b.HasOne("Leave_HR_Management.Models.Employee", null)
                        .WithMany("Departments")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("Leave_HR_Management.Models.Employee", b =>
                {
                    b.HasOne("Leave_HR_Management.Models.Department", "PrimaryDepartment")
                        .WithMany("Employees")
                        .HasForeignKey("PrimaryDepartmentId");
                });

            modelBuilder.Entity("Leave_HR_Management.Models.LeaveApprover", b =>
                {
                    b.HasOne("Leave_HR_Management.Models.Department", null)
                        .WithMany("LeaveApprovers")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("Leave_HR_Management.Models.Employee", "Employee")
                        .WithMany("LeaveApprovers")
                        .HasForeignKey("EmployeeId");
                });
#pragma warning restore 612, 618
        }
    }
}
