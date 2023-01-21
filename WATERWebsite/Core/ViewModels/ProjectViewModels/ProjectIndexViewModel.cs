namespace WATERWebsite.Core.ViewModels.ProjectViewModels
{
    public class ProjectIndexViewModel
    {
        public int ProjectCode { get; set; }
        public string? ProjectName { get; set; }
        public string? ProjectLocation { get; set; }
        public string? ProjectPhotoPath { get; set; }
        public List<string>? Services { get; set; }
        public List<string>? Divisions { get; set; }
    }
}
