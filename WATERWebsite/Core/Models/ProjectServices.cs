namespace WATERWebsite.Core.Models
{
    public class ProjectServices
    {
        public int ProjectCode { get; set; }
        public int ServiceCode { get; set; }
        public virtual Project? ProjectCodeNavigation { get; set; }
        public virtual Service? ServiceCodeNavigation { get; set; }
    }
}
