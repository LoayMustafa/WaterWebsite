namespace WATERWebsite.Core.Models
{
    public class ServiceItem
    {
        public ServiceItem()
        {
            this.SpecializedServices = new List<SpecializedService>();
            this.Projects = new List<Project>();
        }
        public int ServiceItemCode { get; set; }
        public string ServiceItemNameE { get; set; } = string.Empty;
        public string ServiceItemNameA { get; set; } = string.Empty;
        public string? ServiceItemDescriptionE { get; set; } = string.Empty;
        public string? ServiceItemDescriptionA { get; set; } = string.Empty;
        public virtual ICollection<SpecializedService>? SpecializedServices { get; set; }
        public virtual ICollection<Project>? Projects { get; set; }
        public List<SpecializedServicesItems>? SpecializedServicesItems { get; set; }
        public List<ProjectsServiceItems>? ProjectsServiceItems { get; set; }

    }
}
