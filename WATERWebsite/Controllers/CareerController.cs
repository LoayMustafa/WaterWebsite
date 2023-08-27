using Microsoft.AspNetCore.Mvc;
using WATERWebsite.Core.ViewModels.ContactUsViewModels;
using WATERWebsite.Core.ViewModels.JobViewModels;
using WATERWebsite.Presistance;
using WATERWebsite.Services;

namespace WATERWebsite.Controllers
{
    public class CareerController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IMailingService _mailingService;
        private string lang = "en";

        public CareerController(ApplicationDbContext context, IMailingService mailingService)
        {
            _db = context;
            _mailingService = mailingService;
        }
        public IActionResult Index()
        {
            lang = HttpContext?.Session.GetString("lang") ?? "en";
            var jobs = _db.Job.Where(c => c.IsAvailable).Select(c => new JobIndexViewModel
            {
                JobName = lang == "ar" ? c.JobNameA : c.JobNameE,
                JobDescription = lang == "ar" ? c.JobDescriptionA : c.JobDescriptionE,
				IsAvailable = c.IsAvailable
			}).ToList();
            return View(jobs);
        }

        [HttpPost]
        public async Task<IActionResult> SendMail([FromForm] ContactUsMailViewModel viewModel)
        {
            var mailTo = "career@water-consult.com";
            var isApp = true;
            await _mailingService.SendEmailAsync(mailTo, viewModel.EmailFrom, viewModel.ClientName, viewModel.ClientNumber,
                            viewModel.Subject, viewModel.body, viewModel.Attachments, isApp);

            return Json(new { success = true });
        }
    }
}
