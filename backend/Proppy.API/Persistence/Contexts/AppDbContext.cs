using Microsoft.EntityFrameworkCore;
using Proppy.API.Domain.Models;
using System;

namespace Proppy.API.Persistence.Contexts
{
    public class AppDbContext: DbContext
    {
        public DbSet<Position> Positions {get; set;}
        public DbSet<Employee> Employees {get; set;}
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Position>().ToTable("Positions");
            builder.Entity<Position>().HasKey(p => p.Code);
            builder.Entity<Position>().HasIndex(p => p.Code).IsUnique();
            builder.Entity<Position>().Property(p => p.Code).HasColumnType("varchar(2)").HasMaxLength(2).IsRequired();
            builder.Entity<Position>().Property(p => p.Description).HasColumnType("varchar(20)").HasMaxLength(20).IsRequired();
            builder.Entity<Position>().HasIndex(p => p.Description).IsUnique();
            builder.Entity<Position>().HasMany(p => p.Employees).WithOne(p => p.Position).HasForeignKey(p => p.Position_Code).IsRequired();

            builder.Entity<Position>().HasData
            (
                new Position { Code = "A", Description = "Senior Manager"},
                new Position { Code = "B", Description = "Manager"},
                new Position { Code = "C", Description = "Engineer"},
                new Position { Code = "D", Description = "Designer"}
            );

            builder.Entity<Employee>().ToTable("Employees");
            builder.Entity<Employee>().HasKey(p => p.ID);
            builder.Entity<Employee>().Property(p => p.ID).HasColumnType("bigint").HasMaxLength(19).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Employee>().HasIndex(p => p.ID).IsUnique();
            builder.Entity<Employee>().Property(p => p.Name).HasColumnType("varchar(30)").HasMaxLength(30).IsRequired();
            builder.Entity<Employee>().Property(p => p.Phone_No).HasColumnType("varchar(20)").HasMaxLength(20).IsRequired();
            builder.Entity<Employee>().HasIndex(p => p.Phone_No).IsUnique();
            builder.Entity<Employee>().Property(p => p.Email).HasColumnType("varchar(30)").HasMaxLength(30).IsRequired();
            builder.Entity<Employee>().HasIndex(p => p.Email).IsUnique();
            builder.Entity<Employee>().Property(p => p.Gender).HasColumnType("varchar(1)").HasMaxLength(1).IsRequired();
            builder.Entity<Employee>().HasOne(p => p.Position).WithMany(p => p.Employees).HasForeignKey(p => p.Position_Code).IsRequired();
            builder.Entity<Employee>().Property(p => p.DOB).HasColumnType("date").HasMaxLength(16).IsRequired();
            builder.Entity<Employee>().Property(p => p.Salary).HasColumnType("decimal(16)").HasMaxLength(16).IsRequired();
            builder.Entity<Employee>().Property(p => p.Remarks).HasColumnType("varchar(1000)").HasMaxLength(1000);
            builder.Entity<Employee>().Property(p => p.Photo).HasColumnType("varchar(30)").HasMaxLength(30).IsRequired();
            builder.Entity<Employee>().HasIndex(p => p.Photo).IsUnique();

            builder.Entity<Employee>().HasData
            (
                new Employee
                {
                    ID = 1,
                    Name = "Mary Tan",
                    Phone_No = "0161234567",
                    Email = "abc@gmail.com",
                    Gender = "F",
                    Position_Code = "A",
                    DOB = new DateTime(1970, 1, 25),
                    Salary = 5000,
                    Remarks = "",
                    Photo = "https://images.unsplash.com/1",
                },
                new Employee
                {
                    ID = 2,
                    Name = "Aliasgar",
                    Phone_No = "+60161234568",
                    Email = "xyz@yahoo.com",
                    Gender = "M",
                    Position_Code = "B",
                    DOB = new DateTime(1971, 3, 2),
                    Salary = 3500,
                    Remarks = "",
                    Photo = "https://images.unsplash.com/2",
                },
                new Employee
                {
                    ID = 3,
                    Name = "Justin Biieber",
                    Phone_No = "0161234569",
                    Email = "abc2@gmail.com",
                    Gender = "M",
                    Position_Code = "B",
                    DOB = new DateTime(1972, 5, 25),
                    Salary = 3300,
                    Remarks = "",
                    Photo = "https://images.unsplash.com/3",
                }
            );
        }
    }
}