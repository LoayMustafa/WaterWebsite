namespace WATERWebsite.Core.ViewModels.DepartmentViewModels
{
    public class DeprtmentIndexViewModel
    {
        public int DepartmentCode { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public string? DepartmentBrief { get; set; }
        public string? DepartmentOverviewE { get; set; }
        public string? DepartmentEndE { get; set; }
        public string? DepartmentPhotoPath { get; set; }
        public string? DepartmentLogoPath { get; set; }
        public string? HomeDescA { get; set; }
    }
}
