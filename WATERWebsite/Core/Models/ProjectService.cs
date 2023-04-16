namespace WATERWebsite.Core.Models
{
    public class ProjectService
    {
        public int ProjectCode { get; set; }
        public virtual Project? Project { get; set; }
        public int ServiceCode { get; set; }
        public virtual Service? Service { get; set; }
    }
}
