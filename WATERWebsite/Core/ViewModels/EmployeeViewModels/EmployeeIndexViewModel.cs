namespace WATERWebsite.Core.ViewModels.EmployeeViewModels
{
    public class EmployeeIndexViewModel
    {
        public int EmployeeCode { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public string? EmployeeJob { get; set; }
        public string? EmployeeBio { get; set; }
        public string? EmployeePhotoPath { get; set; }
        public string? EmployeePhone { get; set; }
        public string? EmployeeEmail { get; set; }
        public string? EmployeeCV { get; set; }
        public int EmployeeLvl { get; set; }
    }
}
