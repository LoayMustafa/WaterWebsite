namespace WATERWebsite.Core.Models
{
    public class Employee
    {
        public int EmployeeCode { get; set; }
        public string EmployeeNameE { get; set; } = string.Empty;
        public string EmployeeJobE { get; set; } = string.Empty;
        public string? EmployeeDescriptionE { get; set; }
        public string EmployeeNameA { get; set; } = string.Empty;
        public string EmployeeJobA { get; set; } = string.Empty; 
        public string? EmployeeDescriptionA { get; set; }
        public string? EmployeePhotoPath { get; set; }
        public string? EmployeePhone { get; set; }
        public string? EmployeeEmail { get; set; }
        public string? EmployeeCV { get; set; }
        public bool? IsKey { get; set; }
    }
}
