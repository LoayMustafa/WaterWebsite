using WATERWebsite.Core.DTOs.ServiceDtos;
using WaterClassLibrary.Core.Models;

namespace WATERWebsite.Core.ViewModels
{
    public class ServiceDetailsDto
    {
        public int ServiceDetailCode { get; set; }
        public string ServiceDetailName { get; set; } = string.Empty;
        public string? ServiceDetailBrief { get; set; }
        public string? ServiceDetailOverview { get; set; }
        public string? ServiceDetailEnd { get; set; }
        public List<ServiceDetailSpecificsDto>? ServiceDetailSpecifics { get; set; }
        public List<ServiceDetailsDto>? ServiceDetailList { get; set; }
        public bool IsClickable { get; set; }

    }
}
