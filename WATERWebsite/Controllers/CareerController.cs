using Microsoft.AspNetCore.Mvc;
using WATERWebsite.Core.Models;
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
        [HttpGet]
        public IActionResult Jobs()
        {
            lang = HttpContext?.Session.GetString("lang") ?? "en";
            var jobs = _db.Job.Select(c => new JobIndexViewModel
            {
                JobName = lang == "ar" ? c.JobNameA : c.JobNameE,
                JobDescription = lang == "ar" ? c.JobDescriptionA : c.JobDescriptionE,
                IsAvailable = c.IsAvailable
            }).ToList();
            return View(jobs);
        }
        [HttpGet]
        public IActionResult AddJob()
        {
            return PartialView("_AddJobPartial");
        }
        [HttpPost]
        public IActionResult AddJob(string jobName, string jobDesc)
        {
            Job record = new Job
            {
                JobNameE = jobName,
                JobDescriptionE = jobDesc,
                IsAvailable = true,
                JobDescriptionA = jobDesc,
                JobNameA = jobName
            };
            _db.Job.Add(record);
            _db.SaveChanges();

            return RedirectToAction("Jobs");
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
