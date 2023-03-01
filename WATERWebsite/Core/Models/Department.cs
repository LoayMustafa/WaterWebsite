namespace WATERWebsite.Core.Models
{
    public class Department
    {
        public Department()
        {
            Services = new HashSet<Service>();
        }
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
        public string? DepartmentLogoPath { get; set; }

        public virtual ICollection<Service>? Services { get; set; }
    }
}
