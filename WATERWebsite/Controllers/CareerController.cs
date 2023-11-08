using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public IActionResult Jobs()
        {
            var jobs = _db.Job.Select(c => new JobIndexViewModel
            {
                JobCode = c.JobCode,
                JobName = c.JobNameE,
                JobDescription = c.JobDescriptionE,
                IsAvailable = c.IsAvailable
            }).ToList();
            return View(jobs);
        }
        [HttpGet]
        public IActionResult AddJob(int? JobCode)
        {
            var model = new JobActionViewModel();
            if (JobCode != null)
            {
                var job = _db.Job.Find(JobCode);
                if (job != null)
                {
                    model = new JobActionViewModel
                    {
                        JobNameA = job.JobNameA,
                        JobNameE = job.JobNameE,
                        JobDescriptionA = job.JobDescriptionA,
                        JobDescriptionE = job.JobDescriptionE,
                        IsAvailable = job.IsAvailable,
                    };
                }
            }
            return PartialView("_AddJobPartial", model);
        }
        [HttpPost]
        public IActionResult AddJob(JobActionViewModel viewModel)
        {
            if (viewModel.JobCode != 0)
            {
                var job = _db.Job.Find(viewModel.JobCode);
                if (job != null)
                {
                    job.JobNameE = viewModel.JobNameE;
                    job.JobDescriptionE = viewModel.JobDescriptionE;
                    job.IsAvailable = viewModel.IsAvailable;
                    job.JobDescriptionA = viewModel.JobDescriptionA;
                    job.JobNameA = viewModel.JobNameA;
                }
            }
            else
            {
                Job record = new Job
                {
                    JobNameE = viewModel.JobNameE,
                    JobDescriptionE = viewModel.JobDescriptionE,
                    IsAvailable = viewModel.IsAvailable,
                    JobDescriptionA = viewModel.JobDescriptionA,
                    JobNameA = viewModel.JobNameA
                };
                _db.Job.Add(record);
            }
            _db.SaveChanges();

            return RedirectToAction("Jobs");
        }
        [HttpGet]
        public IActionResult RemoveJob(int JobCode)
        {
            var job = _db.Job.Find(JobCode);
            if (job != null)
            {
                _db.Job.Remove(job);
                _db.SaveChanges();
                return Json(new { success = true, msg = "Deleted Successfully" });
            }
            return Json(new { success = false });

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
