namespace WATERWebsite.Core.ViewModels.AboutUsViewModels
{
    public class AboutUsTeamViewModel
    {
        public int EmployeeCode { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public string? EmployeeJob { get; set; } = string.Empty;
        public string? EmployeePhotoPath { get; set; }
        public string? EmployeeBio { get; set; }

    }
}
