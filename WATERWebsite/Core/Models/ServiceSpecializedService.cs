namespace WATERWebsite.Core.Models
{
    public class ServiceSpecializedService
    {
        public int ServiceId { get; set; }
        public Service? Service { get; set; }
        public int SpecializedServiceId { get; set; }
        public SpecializedService? SpecializedService { get; set; }
    }
}
