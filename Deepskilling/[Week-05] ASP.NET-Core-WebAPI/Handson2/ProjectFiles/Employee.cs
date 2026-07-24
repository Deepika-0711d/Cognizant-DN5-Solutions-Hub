namespace EmployeeAPI.Models
{
    public class Employee
    {
        public int empId { get; set; }
        public string empName { get; set; }
        public string empEmail { get; set; }
        public decimal empSalary { get; set; }
        public string empPosition { get; set; }
        public DateTime empJoinDate { get; set; }
        public int deptId { get; set; }
    }
}
