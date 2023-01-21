using Microsoft.Build.Framework;

namespace WATERWebsite.Core.ViewModels.ContactUsViewModels
{
    public class ContactUsMailViewModel
    {
        public string EmailFrom { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string ClientName { get; set; } = string.Empty;
        public string ClientNumber { get; set; } = string.Empty;
        public string body { get; set; } = string.Empty;
        public IList<IFormFile>? Attachments { get; set; }

    }
}
