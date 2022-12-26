namespace WATERWebsite.Core.Models
{
    public class SpecializedServicesItems
    {
        public SpecializedService? SpecializedServices { get; set; }
        public int SpecializedServiceId { get; set; }
        public ServiceItem? ServiceItems { get; set; }
        public int ServiceItemId { get; set; }
    }
}
