using Microsoft.AspNetCore.Mvc;
using WATERWebsite.Core.DTOs;
using WATERWebsite.Core.DTOs.BlogDtos;
using WATERWebsite.Core.DTOs.ProjectDtos;
using WATERWebsite.Core.DTOs.ServiceDtos;
using WATERWebsite.Core.ViewModels.HomeViewModels;
using WATERWebsite.Core.ViewModels.ProjectViewModels;
using WATERWebsite.Presistance;

namespace WATERWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private string lang = "en";

        public HomeController(ApplicationDbContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("lang") != null)
            {
                lang = HttpContext?.Session.GetString("lang") ?? "ar";
            }
            //Get Services
            var services = _db.Service.Take(10).Select(c => new ServicesDto
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
            var blogs =_db.Blog.Select(c => new BlogHomeDto
            {
                BlogCode = c.BlogCode,
                BlogBrief = lang == "ar" ? c.BlogBriefA : c.BlogBriefE,
                BlogTitle = lang == "ar" ? c.BlogTitleA : c.BlogTitleE,
                BlogPublisher = lang == "ar" ? c.BlogPublisherA : c.BlogPublisherE,
                BlogDate = c.BlogDate.ToString("dd/MM/yyyy"),
                BlogPhoto = c.BlogPhotoPath,
            }).ToList();

            HomeIndexViewModel viewModel = new HomeIndexViewModel
            {
                ServicesDto = services,
                ProjectHomeDto = projects,
                BlogHomeDto = blogs
            };

            return View(viewModel);
        }
        //public ServicesNavDto servicesNav()
        //{
        //    ServicesNavDto ServicesNavDto = new ServicesNavDto
        //    {

        //    };
        //    return ServicesNavDto;
        //}
        public IActionResult SetLanguage(string lang)
        {
            HttpContext.Session.SetString("lang", lang);
            return Json(new { success = true });
        }
    }
}
