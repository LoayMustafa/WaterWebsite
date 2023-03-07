namespace WATERWebsite.Core.DTOs.ServiceDtos
{
    public class CreateServiceDetailItemDto
    {
        public string ServiceDetailNameE { get; set; } = string.Empty;
        public string ServiceDetailNameA { get; set; } = string.Empty;
        public string? ServiceDetailBriefE { get; set; }
        public string? ServiceDetailBriefA { get; set; }
        public string? ServiceDetailOverviewE { get; set; }
        public string? ServiceDetailOverviewA { get; set; }
        public string? ServiceDetailEndE { get; set; }
        public string? ServiceDetailEndA { get; set; }
    }
}
