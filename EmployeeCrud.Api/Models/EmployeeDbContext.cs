using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeCrud.Api.Models
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, FirstName = "ABC", LastName = "PQR", DateOfBirth = DateTime.Parse("2000/01/20") },
                new Employee { Id = 2, FirstName = "DEF", LastName = "PQR", DateOfBirth = DateTime.Parse("2000/01/21") }
                );
        }
    }
}
