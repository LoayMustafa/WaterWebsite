namespace WATERWebsite.Core.DTOs.ServiceDtos
{
    public class CreateSpecificDto
    {
        public string SpecificNameE { get; set; } = string.Empty;
        public string SpecificNameA { get; set; } = string.Empty;
        public string? SpecificBriefE { get; set; }
        public string? SpecificBriefA { get; set; }
        public string? SpecificOverviewE { get; set; }
        public string? SpecificOverviewA { get; set; }
        public string? SpecificEndE { get; set; }
        public string? SpecificEndA { get; set; }
    }
}
