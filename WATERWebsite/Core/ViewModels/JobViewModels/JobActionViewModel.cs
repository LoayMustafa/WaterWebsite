namespace WATERWebsite.Core.ViewModels.JobViewModels
{
    public class JobActionViewModel
    {
        public int JobCode { get; set; }
        public string JobNameA { get; set; } = string.Empty;
        public string JobNameE { get; set; } = string.Empty;
        public string? JobDescriptionA { get; set; }
        public string? JobDescriptionE { get; set; }
        public bool IsAvailable { get; set; }
    }
}
