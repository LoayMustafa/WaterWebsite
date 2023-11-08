using WaterClassLibrary.Core.Models;

namespace WATERWebsite.Core.ViewModels.DepartmentViewModels
{
    public class DepartmentDetailViewModel
    {
        public int DepartmentCode { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public string? DepartmentBrief { get; set; }
        public string? DepartmentOverview { get; set; }
        public string? DepartmentEnd { get; set; }
        public string? DepartmentPhotoPath { get; set; }
        public string? DepartmentLogoPath { get; set; }

        public List<DepartmentServiceDto>? ServicesList { get; set; }
        public List<DeprtmentIndexViewModel>? DepartmentsList { get; set; }
    }
}
