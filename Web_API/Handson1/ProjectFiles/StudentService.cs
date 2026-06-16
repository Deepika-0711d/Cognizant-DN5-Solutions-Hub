using StudentAPI.Models;

namespace StudentAPI.Services
{
    public class StudentService
    {
        private static List<Student> allStudents = new List<Student>
        {
            new Student { studentId = 1, studentName = "Rajesh Kumar", studentEmail = "rajesh@example.com", studentAge = 20, studentDepartment = "IT", studentGPA = 3.8 },
            new Student { studentId = 2, studentName = "Priya Singh", studentEmail = "priya@example.com", studentAge = 21, studentDepartment = "CS", studentGPA = 3.9 },
            new Student { studentId = 3, studentName = "Amit Patel", studentEmail = "amit@example.com", studentAge = 20, studentDepartment = "IT", studentGPA = 3.7 }
        };

        public List<Student> GetAllStudents()
        {
            return allStudents;
        }

        public Student GetStudentById(int id)
        {
            return allStudents.FirstOrDefault(s => s.studentId == id);
        }

        public Student AddNewStudent(Student newStudent)
        {
            newStudent.studentId = allStudents.Count > 0 ? allStudents.Max(s => s.studentId) + 1 : 1;
            allStudents.Add(newStudent);
            return newStudent;
        }

        public Student UpdateStudentInfo(int id, Student updatedStudent)
        {
            var existingStudent = allStudents.FirstOrDefault(s => s.studentId == id);
            if (existingStudent == null)
                return null;

            existingStudent.studentName = updatedStudent.studentName;
            existingStudent.studentEmail = updatedStudent.studentEmail;
            existingStudent.studentAge = updatedStudent.studentAge;
            existingStudent.studentDepartment = updatedStudent.studentDepartment;
            existingStudent.studentGPA = updatedStudent.studentGPA;

            return existingStudent;
        }

        public bool DeleteStudent(int id)
        {
            var studentToRemove = allStudents.FirstOrDefault(s => s.studentId == id);
            if (studentToRemove == null)
                return false;

            allStudents.Remove(studentToRemove);
            return true;
        }

        public List<Student> SearchByDepartment(string dept)
        {
            return allStudents.Where(s => s.studentDepartment.ToLower() == dept.ToLower()).ToList();
        }
    }
}
