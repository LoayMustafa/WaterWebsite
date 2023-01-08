namespace WATERWebsite.Core.Models
{
    public class ServiceDivisons
    {
        public int ServiceCode { get; set; }
        public int DivisionCode { get; set; }
        public virtual Service? ServiceCodeNavigation { get; set; }
        public virtual Division? DivisionCodeNavigation { get; set; }

    }
}
