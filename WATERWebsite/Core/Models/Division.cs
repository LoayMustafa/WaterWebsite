namespace WATERWebsite.Core.Models
{
    public class Division
    {
        public Division()
        {
            ServiceDivisons = new HashSet<ServiceDivisons>();
            DivisionSubServices = new HashSet<DivisionSubServices>();
        }
        public int DivisionCode { get; set; }
        public string DivisionNameE { get; set; } = string.Empty;
        public string DivisionNameA { get; set; } = string.Empty;
        public string?  DivisionBriefE { get; set; }
        public string? DivisionBriefA { get; set; }
        public ICollection<ServiceDivisons>? ServiceDivisons { get; set; }
        public ICollection<DivisionSubServices>? DivisionSubServices { get; set; }

    }
}
