namespace WATERWebsite.Services
{
    public interface IMailingService
    {
        Task<bool> SendEmailAsync(string mailTo, string mailFrom, string clientName, string clientNumber, string subject, string body, IList<IFormFile>? attachments);
    }
}
