namespace WATERWebsite.Core.Models
{
    public class ServiceDetail
    {
        public int ServiceDetailCode { get; set; }
        public string ServiceDetailNameE { get; set; } = string.Empty;
        public string ServiceDetailNameA { get; set; } = string.Empty;
        public string? ServiceDetailBriefE { get; set; }
        public string? ServiceDetailBriefA { get; set; }
        public string? ServiceDetailOverviewE { get; set; }
        public string? ServiceDetailOverviewA { get; set; }
        public string? ServiceDetailEndE { get; set; }
        public string? ServiceDetailEndA { get; set; }

        public virtual int? ServiceCode { get; set; }
        public virtual Service? ServiceNavigationCode { get; set; }
    }
}
