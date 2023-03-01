namespace WATERWebsite.Core.DTOs.ProjectDtos
{
    public class ProjectHomeDto
    {
        public int ProjectCode { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string ProjectLocation { get; set; } = string.Empty;
        public string? ProjectPhotoPath { get; set; } = string.Empty;
    }
}
