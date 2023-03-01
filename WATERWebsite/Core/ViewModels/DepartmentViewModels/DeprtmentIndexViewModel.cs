namespace WATERWebsite.Core.ViewModels.DepartmentViewModels
{
    public class DeprtmentIndexViewModel
    {
        public int DepartmentCode { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public string? DepartmentBrief { get; set; }
        public string? DepartmentPhotoPath { get; set; }
        public string? DepartmentLogoPath { get; set; }
    }
}
