namespace WATERWebsite.Core.ViewModels.EmployeeViewModels
{
    public class EmployeeIndexViewModel
    {
        public int EmployeeCode { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public string EmployeeJob { get; set; } = string.Empty;
        public string? EmployeeDescription { get; set; }
        public string EmployeePhotoPath { get; set; } = string.Empty;
        public string? EmployeePhone { get; set; }
        public string? EmployeeEmail { get; set; }
        public string? EmployeeCV { get; set; }
        public bool? IsKey { get; set; }
    }
}
