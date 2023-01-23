using Microsoft.AspNetCore.Mvc;
using WATERWebsite.Core.DTOs.ProjectDtos;
using WATERWebsite.Core.DTOs.ServiceDtos;
using WATERWebsite.Core.ViewModels.HomeViewModels;
using WATERWebsite.Core.ViewModels.ProjectViewModels;
using WATERWebsite.Presistance;

namespace WATERWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ApplicationDbContext _db;
        private string lang = "ar";

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment hostingEnvironment, ApplicationDbContext context)
        {
            _db = context;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("lang") != null)
            {
                lang = HttpContext?.Session.GetString("lang") ?? "ar";
            }
            //Get Services
            var services = _db.Service.Select(c => new ServicesDto
            {
                ServiceCode = c.ServiceCode,
                ServiceName = lang == "ar" ? c.ServiceNameA : c.ServiceNameE,
                ServiceBrief = lang == "ar" ? c.ServiceBriefA : c.ServiceBriefE,
                ServiceLogo = c.ServiceLogo
            }).ToList();

            //Get Projects
            var projects = _db.Project.Select(c => new ProjectHomeDto
            {
                ProjectCode = c.ProjectCode,
                ProjectName = lang == "ar" ? c.ProjectNameA : c.ProjectNameE,
                ProjectLocation = lang == "ar" ? c.ProjectLocationA : c.ProjectLocationE,
                ProjectPhotoPath = c.ProjectPhotoPath
            }).ToList();

            //GetPartners

            //GetBlogs


            HomeIndexViewModel viewModel = new HomeIndexViewModel
            {
                ServicesDto = services,
                ProjectHomeDto = projects,
            };

            return View(viewModel);
        }

        public IActionResult SetLanguage(string lang)
        {
            HttpContext.Session.SetString("lang", lang);
            return Json(new { success = true });
        }
    }
}
