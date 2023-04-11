namespace WATERWebsite.Core.Models
{
    public class Projects
    {
        public Projects()
        {
            ProjectSpecific = new HashSet<ProjectSpecific>();
        }
        public int ProjectCode { get; set; }
        public string ProjectNameE { get; set; } = string.Empty;
        public string ProjectNameA { get; set; } = string.Empty;
        public string ProjectLocationE { get; set; } = string.Empty;
        public string ProjectLocationA { get; set; } = string.Empty;
        public string? ProjectOwnerE { get; set; }
        public string? ProjectOwnerA { get; set; }
        public string? ProjectOperatorE { get; set; }
        public string? ProjectOperatorA { get; set; }
        public string? ProjectOverviewE { get; set; }
        public string? ProjectOverviewA { get; set; }
        public long? ProjectCapacity { get; set; }
        public decimal? ProjectCost { get; set; }
        public string? ProjectPhotoPath { get; set; }
        public virtual ICollection<ProjectSpecific>? ProjectSpecific { get; set; }
    }
}
