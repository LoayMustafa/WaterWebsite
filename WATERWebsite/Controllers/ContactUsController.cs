using Microsoft.AspNetCore.Mvc;
using WATERWebsite.Core.ViewModels.ContactUsViewModels;
using WATERWebsite.Services;

namespace WATERWebsite.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly IMailingService _mailingService;
        private string lang = "en";

        public ContactUsController(IMailingService mailingService)
        {
            _mailingService = mailingService;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("lang") != null)
            {
                lang = HttpContext?.Session.GetString("lang") ?? "ar";
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMail([FromForm] ContactUsMailViewModel viewModel)
        {
            await _mailingService.SendEmailAsync("loaybadwy10@gmail.com",viewModel.EmailFrom, viewModel.ClientName, viewModel.ClientNumber, 
                            viewModel.Subject,viewModel.body, viewModel.Attachments);

            return Json(new { success = true });
        }
    }
}
