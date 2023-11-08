namespace WATERWebsite.Core.ViewModels.JobViewModels
{
    public class JobIndexViewModel
    {
        public string JobName { get; set; } = string.Empty;
        public int JobCode { get; set; }
        public string? JobDescription { get; set; }
        public bool IsAvailable { get; set; }
    }
}
