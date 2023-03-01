namespace WATERWebsite.Core.Models
{
    public class Service
    {
        public Service()
        {
            ServiceDetails = new HashSet<ServiceDetail>();
        }
        public int ServiceCode { get; set; }
        public string ServiceNameE { get; set; } = string.Empty;
        public string ServiceNameA { get; set; } = string.Empty;
        public string? ServiceBriefE { get; set; }
        public string? ServiceBriefA { get; set; }
        public string? ServiceOverviewE { get; set; }
        public string? ServiceOverviewA { get; set; }
        public string? ServiceEndE { get; set; }
        public string? ServiceEndA { get; set; }
        public string? ServicePhotoPath { get; set; }
        public string? ServiceLogo { get; set; }

        public int? DepartmentCode { get; set; }
        public virtual Department? DepartmentNavigationCode { get; set; }
        public virtual ICollection<ServiceDetail>? ServiceDetails { get; set; }


    }
}
