namespace WATERWebsite.Core.Models
{
    public class ServiceItem
    {
        public ServiceItem()
        {
            this.SpecializedServices = new List<SpecializedService>();
        }
        public int ServiceItemCode { get; set; }
        public string ServiceItemNameE { get; set; } = string.Empty;
        public string ServiceItemNameA { get; set; } = string.Empty;
        public virtual ICollection<SpecializedService>? SpecializedServices { get; set; }
    }
}
