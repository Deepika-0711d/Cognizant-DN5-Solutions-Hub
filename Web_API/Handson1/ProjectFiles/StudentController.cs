using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models;
using StudentAPI.Services;

namespace StudentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentService studentService;

        public StudentController()
        {
            studentService = new StudentService();
        }

        [HttpGet]
        public ActionResult<List<Student>> GetAllStudents()
        {
            var studentsData = studentService.GetAllStudents();
            return Ok(studentsData);
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            var foundStudent = studentService.GetStudentById(id);
            if (foundStudent == null)
                return NotFound(new { message = "Student not found" });

            return Ok(foundStudent);
        }

        [HttpPost]
        public ActionResult<Student> CreateStudent([FromBody] Student studentData)
        {
            if (studentData == null)
                return BadRequest(new { message = "Invalid student data" });

            var createdStudent = studentService.AddNewStudent(studentData);
            return CreatedAtAction(nameof(GetStudentById), new { id = createdStudent.studentId }, createdStudent);
        }

        [HttpPut("{id}")]
        public ActionResult<Student> UpdateStudent(int id, [FromBody] Student studentData)
        {
            if (studentData == null)
                return BadRequest(new { message = "Invalid student data" });

            var updatedStudent = studentService.UpdateStudentInfo(id, studentData);
            if (updatedStudent == null)
                return NotFound(new { message = "Student not found" });

            return Ok(updatedStudent);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            var isDeleted = studentService.DeleteStudent(id);
            if (!isDeleted)
                return NotFound(new { message = "Student not found" });

            return Ok(new { message = "Student deleted successfully" });
        }

        [HttpGet("department/{deptName}")]
        public ActionResult<List<Student>> GetByDepartment(string deptName)
        {
            var departmentStudents = studentService.SearchByDepartment(deptName);
            if (departmentStudents.Count == 0)
                return NotFound(new { message = "No students found in this department" });

            return Ok(departmentStudents);
        }
    }
}
