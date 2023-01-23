namespace WATERWebsite.Core.Models
{
    public class Blog
    {
        public int BlogCode { get; set; }
        public string BlogTitleE { get; set; } = string.Empty;
        public string BlogTitleA { get; set; } = string.Empty; 
        public string BlogBriefE { get; set; } = string.Empty; 
        public string BlogBriefA { get; set; } = string.Empty; 
        public string BlogContentE { get; set; } = string.Empty; 
        public string BlogContentA { get; set; } = string.Empty; 
        public string BlogPhoto { get; set; } = string.Empty; 
        public DateTime BlogDate { get; set; } 
        public string? BlogPublisherE { get; set; } 
        public string? BlogPublisherA { get; set; } 
    }
}
