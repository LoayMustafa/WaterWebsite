using WATERWebsite.Core.DTOs.ProjectDtos;
using WATERWebsite.Core.Models;

namespace WATERWebsite.Core.ViewModels.ProjectViewModels
{
    public class ProjectDetailsViewModel
    {
        public int ProjectCode { get; set; }
        public decimal? ProjectCost { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string ProjectLocation { get; set; } = string.Empty;
        public long? ProjectCapacity { get; set; }
        public string? ProjectOwner { get; set; }
        public string? ProjectOperator{ get; set; }
        public string? ProjectOverview { get; set; }
        public string? ProjectPhotoPath { get; set; } = string.Empty;
        public List<ProjectServicesDto>? ProjectSpecificsDto { get; set; }
    }
}
