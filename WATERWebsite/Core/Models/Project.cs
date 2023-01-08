namespace WATERWebsite.Core.Models
{
    public class Project
    {
        public Project()
        {
            ProjectServices = new HashSet<ProjectServices>();
        }
        public int ProjectCode { get; set; }
        public string ProjectNameE { get; set; } = string.Empty;
        public string ProjectLocationE { get; set; } = string.Empty;
        public string? ProjectOwnerE { get; set; }
        public string? ProjectOperatorE { get; set; }
        public string? ProjectDeveloperE { get; set; }
        public string? ProjectOverviewE { get; set; }
        public string ProjectNameA { get; set; } = string.Empty;
        public string ProjectLocationA { get; set; } = string.Empty;
        public long? ProjectCapacity { get; set; }
        public string? ProjectOwnerA { get; set; }
        public string? ProjectOperatorA { get; set; }
        public string? ProjectDeveloperA { get; set; }
        public string? ProjectOverviewA { get; set; }
        public string ProjectPhotoPath { get; set; } = string.Empty;
        public DateTime ProjectDate { get; set; }
        public ICollection<ProjectServices>? ProjectServices { get; set; }

    }
}
