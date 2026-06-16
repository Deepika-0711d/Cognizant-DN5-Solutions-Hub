namespace EmployeeAPI.Models
{
    public class Department
    {
        public int deptId { get; set; }
        public string deptName { get; set; }
        public string deptLocation { get; set; }
        public List<Employee> employees { get; set; } = new List<Employee>();
    }
}
