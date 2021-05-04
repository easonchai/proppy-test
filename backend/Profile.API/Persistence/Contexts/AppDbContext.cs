using Microsoft.EntityFrameworkCore;
using Profile.API.Domain.Models;

namespace Profile.API.Persistence.Contexts
{
    public class AppDbContext: DbContext
    {
        public DbSet<Position> Position {get; set;}
        public DbSet<Employee> Employee {get; set;}
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Position>().ToTable("Positions");
            builder.Entity<Position>().HasKey(p => p.Code);
            builder.Entity<Position>().Property(p => p.Code).HasColumnType("varchar").IsRequired().HasMaxLength(2);
            builder.Entity<Position>().Property(p => p.Description).HasColumnType("varchar").IsRequired().HasMaxLength(20);
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
            builder.Entity<Employee>().Property(p => p.ID).HasColumnType("bigint").HasMaxLength(19).IsRequired();
            builder.Entity<Employee>().Property(p => p.Name).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            builder.Entity<Employee>().Property(p => p.Phone_No).HasColumnType("varchar").HasMaxLength(20).IsRequired();
            builder.Entity<Employee>().Property(p => p.Email).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            builder.Entity<Employee>().Property(p => p.Gender).HasColumnType("varchar").HasMaxLength(1).IsRequired();
            builder.Entity<Employee>().HasOne(p => p.Position).WithMany(p => p.Employees).HasForeignKey(p => p.Position_Code).IsRequired();
            builder.Entity<Employee>().Property(p => p.DOB).HasColumnType("date").HasMaxLength(16).IsRequired();
            builder.Entity<Employee>().Property(p => p.Salary).HasColumnType("decimal").HasMaxLength(16).IsRequired();
            builder.Entity<Employee>().Property(p => p.Remarks).HasColumnType("varchar").HasMaxLength(1000);
            builder.Entity<Employee>().Property(p => p.Photo).HasColumnType("varchar").HasMaxLength(30).IsRequired();
        }
    }
}