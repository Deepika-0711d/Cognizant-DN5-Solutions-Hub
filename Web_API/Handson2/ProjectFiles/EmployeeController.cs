using Microsoft.AspNetCore.Mvc;
using EmployeeAPI.Models;
using EmployeeAPI.Services;

namespace EmployeeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService empService;

        public EmployeeController(EmployeeService service)
        {
            empService = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            var empList = await empService.GetAllEmployees();
            return Ok(empList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeDetail(int id)
        {
            var emp = await empService.GetEmployeeById(id);
            if (emp == null)
                return NotFound(new { error = "Employee not found" });

            return Ok(emp);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee([FromBody] Employee empData)
        {
            if (empData == null)
                return BadRequest(new { error = "Invalid employee data" });

            var createdEmp = await empService.AddEmployee(empData);
            return CreatedAtAction(nameof(GetEmployeeDetail), new { id = createdEmp.empId }, createdEmp);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> EditEmployee(int id, [FromBody] Employee empData)
        {
            if (empData == null)
                return BadRequest(new { error = "Invalid employee data" });

            var editedEmp = await empService.UpdateEmployee(id, empData);
            if (editedEmp == null)
                return NotFound(new { error = "Employee not found" });

            return Ok(editedEmp);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveEmployee(int id)
        {
            var isRemoved = await empService.RemoveEmployee(id);
            if (!isRemoved)
                return NotFound(new { error = "Employee not found" });

            return Ok(new { message = "Employee removed successfully" });
        }

        [HttpGet("department/{deptId}")]
        public async Task<ActionResult<List<Employee>>> GetByDepartment(int deptId)
        {
            var deptEmps = await empService.GetEmployeesByDepartment(deptId);
            return Ok(deptEmps);
        }

        [HttpGet("salary/{minAmount}")]
        public async Task<ActionResult<List<Employee>>> GetHighSalaryEmployees(decimal minAmount)
        {
            var highEarners = await empService.GetHighEarners(minAmount);
            return Ok(highEarners);
        }
    }
}
