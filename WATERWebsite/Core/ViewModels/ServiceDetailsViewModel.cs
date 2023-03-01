using WATERWebsite.Core.Models;

namespace WATERWebsite.Core.ViewModels
{
    public class ServiceDetailsViewModel
    {
        public int ServiceCode { get; set; }
        public string ServiceName { get; set; } = string.Empty;
        public string? ServiceOverview { get; set; }
        public string? ServiceBrief { get; set; }
        public string? ServicePhotoPath { get; set; } = string.Empty;
        public string? ServiceLogo { get; set; } = string.Empty;
        public List<ServiceDetailsDto>? ServiceDetails { get; set; }

    }
}
