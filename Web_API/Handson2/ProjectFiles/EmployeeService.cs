using EmployeeAPI.Models;
using EmployeeAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Services
{
    public class EmployeeService
    {
        private readonly AppDbContext dbContext;

        public EmployeeService(AppDbContext context)
        {
            dbContext = context;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await dbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await dbContext.Employees.FirstOrDefaultAsync(e => e.empId == id);
        }

        public async Task<Employee> AddEmployee(Employee newEmployee)
        {
            dbContext.Employees.Add(newEmployee);
            await dbContext.SaveChangesAsync();
            return newEmployee;
        }

        public async Task<Employee> UpdateEmployee(int id, Employee updatedData)
        {
            var employeeRecord = await dbContext.Employees.FirstOrDefaultAsync(e => e.empId == id);
            if (employeeRecord == null)
                return null;

            employeeRecord.empName = updatedData.empName;
            employeeRecord.empEmail = updatedData.empEmail;
            employeeRecord.empSalary = updatedData.empSalary;
            employeeRecord.empPosition = updatedData.empPosition;
            employeeRecord.deptId = updatedData.deptId;

            dbContext.Employees.Update(employeeRecord);
            await dbContext.SaveChangesAsync();
            return employeeRecord;
        }

        public async Task<bool> RemoveEmployee(int id)
        {
            var employeeRecord = await dbContext.Employees.FirstOrDefaultAsync(e => e.empId == id);
            if (employeeRecord == null)
                return false;

            dbContext.Employees.Remove(employeeRecord);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Employee>> GetEmployeesByDepartment(int deptId)
        {
            return await dbContext.Employees.Where(e => e.deptId == deptId).ToListAsync();
        }

        public async Task<List<Employee>> GetHighEarners(decimal minSalary)
        {
            return await dbContext.Employees.Where(e => e.empSalary >= minSalary).OrderByDescending(e => e.empSalary).ToListAsync();
        }
    }
}
