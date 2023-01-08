namespace WATERWebsite.Core.Models
{
    public class SubService
    {
        public SubService()
        {
            DivisionSubServices = new HashSet<DivisionSubServices>();
        }
        public int SubServiceCode { get; set; }
        public string SubServiceNameE { get; set; } = string.Empty;
        public string SubServiceNameA { get; set; } = string.Empty;
        public string SubServiceBriefE { get; set; } = string.Empty;
        public string SubServiceBriefA { get; set; } = string.Empty;
        public ICollection<DivisionSubServices>? DivisionSubServices { get; set; }

    }
}
