using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using System.Collections.Generic;

namespace WATERWebsite.Core.ViewModels.DepartmentViewModels
{
    public class DepartmentActionViewModel
    {
        public int DepartmentCode { get; set; }
        public string DepartmentNameE { get; set; } = string.Empty;
        public string DepartmentNameA { get; set; } = string.Empty;
        public string? DepartmentBriefE { get; set; }
        public string? DepartmentBriefA { get; set; }
        public string? DepartmentOverviewE { get; set; }
        public string? DepartmentOverviewA { get; set; }
        public string? DepartmentEndE { get; set; }
        public string? DepartmentEndA { get; set; }
        public string? DepartmentPhotoPath { get; set; }
        public IFormFile? PhotoFile { get; set; }
        public IFormFile? DepartmentLogoPath { get; set; }
        public string? LogoFile { get; set; }
        public string? HomeDescE { get; set; }
        public string? HomeDescA { get; set; }
        public SelectList Services { get; set; }
        public List<int> ServiceCodes { get; set; }
    }
}
