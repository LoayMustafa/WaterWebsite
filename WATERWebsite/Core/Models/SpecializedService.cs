namespace WATERWebsite.Core.Models
{
    public class SpecializedService
    {
        public SpecializedService()
        {
            this.Services = new List<Service>();
            this.ServiceItems = new List<ServiceItem>();
        }
        public int SpecializedServiceCode { get; set; }
        public string SpecializedServiceNameE { get; set; } = string.Empty;
        public string? SpecializedServiceOverviewE { get; set; }
        public string? SpecializedServiceBriefE { get; set; }
        public string SpecializedServiceNameA { get; set; } = string.Empty;
        public string? SpecializedServiceOverviewA { get; set; }
        public string? SpecializedServiceBriefA { get; set; }
        public string SpecializedServicePhotoPath { get; set; } = string.Empty;
        public string SpecializedServiceLogo { get; set; } = string.Empty;
        public virtual ICollection<Service>? Services { get; set; }
        public virtual ICollection<ServiceItem>? ServiceItems { get; set; }
    }
}
