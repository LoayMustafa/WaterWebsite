namespace WATERWebsite.Core.Models
{
    public class ProjectSpecific
    {
        public int ProjectCode { get; set; }
        public virtual Projects? Project { get; set; }
        public int SpecificCode { get; set; }
        public virtual Specifics? Specific { get; set; }

    }
}
