using Microsoft.EntityFrameworkCore;
using EmployeeAPI.Models;

namespace EmployeeAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>().HasKey(d => d.deptId);
            modelBuilder.Entity<Employee>().HasKey(e => e.empId);

            modelBuilder.Entity<Department>().HasData(
                new Department { deptId = 1, deptName = "IT", deptLocation = "Mumbai" },
                new Department { deptId = 2, deptName = "HR", deptLocation = "Bangalore" },
                new Department { deptId = 3, deptName = "Finance", deptLocation = "Delhi" }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { empId = 1, empName = "Rajesh Kumar", empEmail = "rajesh@company.com", empSalary = 75000, empPosition = "Senior Developer", empJoinDate = new DateTime(2020, 1, 15), deptId = 1 },
                new Employee { empId = 2, empName = "Priya Singh", empEmail = "priya@company.com", empSalary = 65000, empPosition = "Developer", empJoinDate = new DateTime(2021, 3, 20), deptId = 1 },
                new Employee { empId = 3, empName = "Neha Sharma", empEmail = "neha@company.com", empSalary = 55000, empPosition = "HR Executive", empJoinDate = new DateTime(2020, 6, 10), deptId = 2 }
            );
        }
    }
}
