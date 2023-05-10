namespace WATERWebsite.Core.Models
{
    public class OfficeClient
    {
        public int ClientCode { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public string? ClientPhotoPath { get; set; }
    }
}
