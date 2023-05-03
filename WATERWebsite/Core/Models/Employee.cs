namespace WATERWebsite.Core.Models
{
    public class Employee
    {
        public int EmployeeCode { get; set; }
        public string EmployeeNameE { get; set; } = string.Empty;
        public string EmployeeNameA { get; set; } = string.Empty;
        public string? EmployeeJobA { get; set; } 
        public string? EmployeeJobE { get; set; }
        public string? EmployeeBioE { get; set; }
        public string? EmployeeBioA { get; set; }
        public string? EmployeePhotoPath { get; set; }
        public string? EmployeePhone { get; set; }
        public string? EmployeeEmail { get; set; }
        public string? EmployeeLinkedIn { get; set; }
        public string? EmployeeCV { get; set; }
        public int EmployeeLevel { get; set; }
    }
}
