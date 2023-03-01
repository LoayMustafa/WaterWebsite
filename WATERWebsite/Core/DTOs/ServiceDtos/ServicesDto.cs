namespace WATERWebsite.Core.DTOs.ServiceDtos
{
    public class ServicesDto
    {
        public int ServiceCode { get; set; }
        public string ServiceName { get; set; } = string.Empty;
        public string? ServiceBrief { get; set; }
        public string? ServiceLogo { get; set; } = string.Empty;
    }
}
