namespace WATERWebsite.Core.Models
{
    public class Service
    {
        public Service()
        {
            this.Projects = new List<Project>();
            this.SpecializedServices = new List<SpecializedService>();
        }
        public int ServiceCode { get; set; }
        public string ServiceNameE { get; set; } = string.Empty;
        public string? ServiceOverviewE { get; set; }
        public string? ServiceBriefE { get; set; }
        public string ServiceNameA { get; set; } = string.Empty;
        public string? ServiceOverviewA { get; set; }
        public string? ServiceBriefA { get; set; }
        public string ServicePhotoPath { get; set; } = string.Empty;
        public string ServiceLogo { get; set; } = string.Empty;
        public virtual ICollection<Project>? Projects { get; set; }
        public virtual ICollection<SpecializedService>? SpecializedServices { get; set; }
        public List<ServiceProject>? ServiceProjects { get; set; }
        public List<ServiceSpecializedService>? ServiceSpecializedServices { get; set; }
    }
}
