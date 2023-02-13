namespace WATERWebsite.Core.ViewModels.BlogViewModels
{
    public class BlogIndexViewModel
    {
        public int BlogCode { get; set; }
        public string BlogTitle { get; set; } = string.Empty;
        public string BlogBrief { get; set; } = string.Empty;
        public string BlogContent { get; set; } = string.Empty;
        public string? BlogPhoto { get; set; } = string.Empty;
        public string BlogDate { get; set; } = string.Empty;
        public string? BlogPublisher { get; set; }
    }
}
