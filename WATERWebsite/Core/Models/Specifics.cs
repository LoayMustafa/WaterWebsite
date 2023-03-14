namespace WATERWebsite.Core.Models
{
    public class Specifics
    {
        public int SpecificsCode { get; set; }
        public string SpecificsNameE { get; set; } = string.Empty;
        public string SpecificsNameA { get; set; } = string.Empty;
        public string? SpecificsBriefE { get; set; }
        public string? SpecificsBriefA { get; set; }
        public string? SpecificsOverviewE { get; set; }
        public string? SpecificsOverviewA { get; set; }
        public string? SpecificsEndE { get; set; }
        public string? SpecificsEndA { get; set; }

        public virtual int? ServiceDetailCode { get; set; }
        public virtual ServiceDetail? ServiceDetailNavigationCode { get; set; }
    }
}
