using WATERWebsite.Core.Models;

namespace WATERWebsite.Core.DTOs
{
    public class CreateServiceDto
    {
        public int ServiceCode { get; set; }
        public string ServiceNameE { get; set; } = string.Empty;
        public string? ServiceOverviewE { get; set; }
        public string? ServiceBriefE { get; set; }
        public string ServiceNameA { get; set; } = string.Empty;
        public string? ServiceOverviewA { get; set; }
        public string? ServiceBriefA { get; set; }
        public string ServicePhotoPath { get; set; } = string.Empty;
        public string ServiceLogo { get; set; } = string.Empty;
        public List<int> ProjectCodes { get; set; }
        public List<int> DivisionCodes { get; set; }
    }
}
