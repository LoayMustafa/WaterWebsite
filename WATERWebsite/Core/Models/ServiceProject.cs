namespace WATERWebsite.Core.Models
{
    public class ServiceProject
    {
        public int ServiceId { get; set; }
        public Service? Service { get; set; }
        public int ProjectId { get; set; }
        public Project? Project { get; set; }
    }
}
