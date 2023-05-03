namespace WATERWebsite.Core.DTOs.ServiceDtos
{
    public class DepartmentsHomeDto
    {
        public int DepartementCode { get; set; }
        public string DepartementName { get; set; } = string.Empty;
        public string? DepartementBrief { get; set; }
        public string? DepartementLogo { get; set; } = string.Empty;
    }
}
