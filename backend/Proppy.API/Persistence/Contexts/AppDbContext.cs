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
                new Position { Code = "D", Description = "Designer"},
                new Position { Code = "E", Description = "CEO"},
                new Position { Code = "F", Description = "COO"},
                new Position { Code = "G", Description = "CTO"},
                new Position { Code = "H", Description = "CMO"}
            );

            builder.Entity<Employee>().ToTable("Employees");
            builder.Entity<Employee>().HasKey(p => p.ID);
            builder.Entity<Employee>().Property(p => p.ID).HasColumnType("bigint").HasMaxLength(19).IsRequired();
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
                    ID = 1L,
                    Name = "Mary Tan",
                    Phone_No = "0161234567",
                    Email = "abc@gmail.com",
                    Gender = "F",
                    Position_Code = "A",
                    DOB = new DateTime(1970, 1, 25),
                    Salary = 5000,
                    Remarks = "",
                    Photo = "https://picsum.photos/501",
                },
                new Employee
                {
                    ID = 2L,
                    Name = "Aliasgar",
                    Phone_No = "+60161234568",
                    Email = "xyz@yahoo.com",
                    Gender = "M",
                    Position_Code = "B",
                    DOB = new DateTime(1971, 3, 2),
                    Salary = 3500,
                    Remarks = "",
                    Photo = "https://picsum.photos/502",
                },
                new Employee
                {
                    ID = 3L,
                    Name = "Justin Biieber",
                    Phone_No = "0161234569",
                    Email = "abc2@gmail.com",
                    Gender = "M",
                    Position_Code = "B",
                    DOB = new DateTime(1972, 5, 25),
                    Salary = 3300,
                    Remarks = "",
                    Photo = "https://picsum.photos/503",
                },
                new Employee
                {
                    ID = 4L,
                    Name = "Chow Yun Fatt",
                    Phone_No = "0161234570",
                    Email = "xyz2@yahoo.com",
                    Gender = "M",
                    Position_Code = "C",
                    DOB = new DateTime(1973, 2, 13),
                    Salary = 2800,
                    Remarks = "",
                    Photo = "https://picsum.photos/504",
                },
                new Employee
                {
                    ID = 5L,
                    Name = "Angela Baby",
                    Phone_No = "0161234571",
                    Email = "abc3@gmail.com",
                    Gender = "F",
                    Position_Code = "D",
                    DOB = new DateTime(1974, 8, 8),
                    Salary = 2700,
                    Remarks = "",
                    Photo = "https://picsum.photos/505",
                },
                new Employee
                {
                    ID = 6L,
                    Name = "Mohd Rizal",
                    Phone_No = "+80161234569",
                    Email = "xyz3@yahoo.com",
                    Gender = "M",
                    Position_Code = "C",
                    DOB = new DateTime(1975, 1, 23),
                    Salary = 2500,
                    Remarks = "",
                    Photo = "https://picsum.photos/506",
                },
                new Employee
                {
                    ID = 7L,
                    Name = "Ken yoong",
                    Phone_No = "+50161234571",
                    Email = "abc4@gmail.com",
                    Gender = "M",
                    Position_Code = "D",
                    DOB = new DateTime(1976, 1, 31),
                    Salary = 2550,
                    Remarks = "",
                    Photo = "https://picsum.photos/507",
                },
                new Employee
                {
                    ID = 8L,
                    Name = "Willson Wong",
                    Phone_No = "+44161234533",
                    Email = "xyz4@yahoo.com",
                    Gender = "M",
                    Position_Code = "A",
                    DOB = new DateTime(1977, 2, 28),
                    Salary = 5500,
                    Remarks = "",
                    Photo = "https://picsum.photos/508",
                },
                new Employee
                {
                    ID = 9L,
                    Name = "Vivian Chong",
                    Phone_No = "0161234575",
                    Email = "abc5@gmail.com",
                    Gender = "F",
                    Position_Code = "F",
                    DOB = new DateTime(1978, 12, 25),
                    Salary = 7000,
                    Remarks = "",
                    Photo = "https://picsum.photos/509",
                },
                new Employee
                {
                    ID = 10L,
                    Name = "Shirley Tan Wai Ling",
                    Phone_No = "0161234576",
                    Email = "xyz5@yahoo.com",
                    Gender = "F",
                    Position_Code = "E",
                    DOB = new DateTime(1979, 1, 7),
                    Salary = 8000,
                    Remarks = "",
                    Photo = "https://picsum.photos/510",
                },
                new Employee
                {
                    ID = 11L,
                    Name = "Mary Tan 2",
                    Phone_No = "01612345672",
                    Email = "abc9@gmail.com",
                    Gender = "F",
                    Position_Code = "A",
                    DOB = new DateTime(1980, 1, 25),
                    Salary = 5000,
                    Remarks = "",
                    Photo = "https://picsum.photos/511",
                },
                new Employee
                {
                    ID = 12L,
                    Name = "Aliasgar 2",
                    Phone_No = "+601612345682",
                    Email = "xyz9@yahoo.com",
                    Gender = "M",
                    Position_Code = "B",
                    DOB = new DateTime(1981, 3, 2),
                    Salary = 3500,
                    Remarks = "",
                    Photo = "https://picsum.photos/512",
                },
                new Employee
                {
                    ID = 13L,
                    Name = "Justin Biieber 2",
                    Phone_No = "01612345692",
                    Email = "abc29@gmail.com",
                    Gender = "M",
                    Position_Code = "B",
                    DOB = new DateTime(1982, 5, 25),
                    Salary = 3300,
                    Remarks = "",
                    Photo = "https://picsum.photos/513",
                },
                new Employee
                {
                    ID = 14L,
                    Name = "Chow Yun Fatt 2",
                    Phone_No = "01612345702",
                    Email = "xyz29@yahoo.com",
                    Gender = "M",
                    Position_Code = "C",
                    DOB = new DateTime(1983, 2, 13),
                    Salary = 2800,
                    Remarks = "",
                    Photo = "https://picsum.photos/514",
                },
                new Employee
                {
                    ID = 15L,
                    Name = "Angela Baby 2",
                    Phone_No = "01612345712",
                    Email = "abc39@gmail.com",
                    Gender = "F",
                    Position_Code = "D",
                    DOB = new DateTime(1984, 8, 8),
                    Salary = 2700,
                    Remarks = "",
                    Photo = "https://picsum.photos/515",
                },
                new Employee
                {
                    ID = 16L,
                    Name = "Mohd Rizal 2",
                    Phone_No = "+801612345692",
                    Email = "xyz39@yahoo.com",
                    Gender = "M",
                    Position_Code = "C",
                    DOB = new DateTime(1985, 1, 23),
                    Salary = 2500,
                    Remarks = "",
                    Photo = "https://picsum.photos/516",
                },
                new Employee
                {
                    ID = 17L,
                    Name = "Ken yoong 2",
                    Phone_No = "+501612345712",
                    Email = "abc49@gmail.com",
                    Gender = "M",
                    Position_Code = "D",
                    DOB = new DateTime(1986, 1, 31),
                    Salary = 2550,
                    Remarks = "",
                    Photo = "https://picsum.photos/517",
                },
                new Employee
                {
                    ID = 18L,
                    Name = "Willson Wong 2",
                    Phone_No = "+441612345332",
                    Email = "xyz49@yahoo.com",
                    Gender = "M",
                    Position_Code = "A",
                    DOB = new DateTime(1987, 2, 28),
                    Salary = 5500,
                    Remarks = "",
                    Photo = "https://picsum.photos/518",
                },
                new Employee
                {
                    ID = 19L,
                    Name = "Vivian Chong 2",
                    Phone_No = "01612345752",
                    Email = "abc59@gmail.com",
                    Gender = "F",
                    Position_Code = "G",
                    DOB = new DateTime(1988, 12, 25),
                    Salary = 7000,
                    Remarks = "",
                    Photo = "https://picsum.photos/519",
                },
                new Employee
                {
                    ID = 20L,
                    Name = "Shirley Tan Wai Ling 2",
                    Phone_No = "01612345762",
                    Email = "xyz59@yahoo.com",
                    Gender = "F",
                    Position_Code = "H",
                    DOB = new DateTime(1989, 1, 7),
                    Salary = 8000,
                    Remarks = "",
                    Photo = "https://picsum.photos/520",
                }
            );
        }
    }
}