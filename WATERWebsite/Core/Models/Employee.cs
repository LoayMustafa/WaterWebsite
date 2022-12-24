namespace WATERWebsite.Core.Models
{
    public class Employee
    {
        public Employee()
        {
            this.Projects = new HashSet<Project>();
        }
        public int EmployeeCode { get; set; }
        public string EmployeeNameE { get; set; } = string.Empty;
        public string EmployeeJobE { get; set; } = string.Empty;
        public string EmployeeNameA { get; set; } = string.Empty;
        public string EmployeeJobA { get; set; } = string.Empty; 
        public string EmployeePhotoPath { get; set; } = string.Empty;
        public string? EmployeePhone { get; set; }
        public string? EmployeeDescription { get; set; }
        public string? EmployeeEmail { get; set; }
        public string? EmployeeCV { get; set; }
        public string? Skills { get; set; }
        public string? Links { get; set; }
        public virtual ICollection<Project>? Projects { get; set; }

    }
}
