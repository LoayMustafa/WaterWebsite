using Microsoft.AspNetCore.Mvc;
using WATERWebsite.Core.ViewModels.JobViewModels;
using WATERWebsite.Presistance;

namespace WATERWebsite.Controllers
{
    public class CareerController : Controller
    {
        private readonly ApplicationDbContext _db;
        private string lang = "en";

        public CareerController(ApplicationDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
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
    }
}
