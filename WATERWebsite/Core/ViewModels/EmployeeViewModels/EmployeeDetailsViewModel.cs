namespace WATERWebsite.Core.ViewModels.EmployeeViewModels
{
    public class EmployeeDetailsViewModel
    {
        public string EmployeeName { get; set; } = string.Empty;
        public string? EmployeeJob { get; set; }
        public string? EmployeePhotoPath { get; set; }
        public string? EmployeePhone { get; set; }
        public string? EmployeeDescription { get; set; }
        public string? EmployeeEmail { get; set; }
        public string? EmployeeLinkedIn { get; set; }
        public List<string>? Skills { get; set; }

    }
}
