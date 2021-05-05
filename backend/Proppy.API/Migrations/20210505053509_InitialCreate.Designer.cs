﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proppy.API.Persistence.Contexts;

namespace Proppy.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210505053509_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Proppy.API.Domain.Models.Employee", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasMaxLength(19);

                    b.Property<DateTime>("DOB")
                        .HasColumnType("date")
                        .HasMaxLength(16);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("varchar(1)")
                        .HasMaxLength(1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Phone_No")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Position_Code")
                        .IsRequired();

                    b.Property<string>("Remarks")
                        .HasColumnType("varchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(16)")
                        .HasMaxLength(16);

                    b.HasKey("ID");

                    b.HasIndex("Position_Code");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Proppy.API.Domain.Models.Position", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(2)")
                        .HasMaxLength(2);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Code");

                    b.ToTable("Positions");

                    b.HasData(
                        new { Code = "A", Description = "Senior Manager" },
                        new { Code = "B", Description = "Manager" },
                        new { Code = "C", Description = "Engineer" },
                        new { Code = "D", Description = "Designer" }
                    );
                });

            modelBuilder.Entity("Proppy.API.Domain.Models.Employee", b =>
                {
                    b.HasOne("Proppy.API.Domain.Models.Position", "Position")
                        .WithMany("Employees")
                        .HasForeignKey("Position_Code")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}