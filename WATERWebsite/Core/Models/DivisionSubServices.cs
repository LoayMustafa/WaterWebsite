namespace WATERWebsite.Core.Models
{
    public class DivisionSubServices
    {
        public int DivisionCode { get; set; }
        public int SubServiceCode { get; set; }
        public virtual Division? DivisionCodeNavigation { get; set; }
        public virtual SubService? SubServiceCodeNavigation { get; set; }
    }
}
