using Microsoft.AspNetCore.Mvc;
using WATERWebsite.Core.Models;
using WATERWebsite.Core.ViewModels;
using WATERWebsite.Presistance;

namespace WATERWebsite.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private string lang = "en";

        public ServicesController(ApplicationDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            //if (HttpContext.Session.GetString("lang") != null)
            //{
            //    lang = HttpContext?.Session.GetString("lang") ?? "ar";
            //}

            var services = _db.Service.ToList();
            List<ServicesIndexViewModel> servicesList = new List<ServicesIndexViewModel>();

            foreach (var service in services)
            {
                ServicesIndexViewModel serviceItem = new ServicesIndexViewModel()
                {
                    ServiceCode = service.ServiceCode,
                    ServiceName = lang == "ar" ? service.ServiceNameA : service.ServiceNameE,
                    ServiceBrief = lang == "ar" ? service.ServiceBriefA : service.ServiceBriefE,
                    ServiceOverview = lang == "ar" ? service.ServiceOverviewA : service.ServiceOverviewE,
                    ServiceLogo = service.ServiceLogo,
                    ServicePhotoPath = service.ServicePhotoPath
                };
                servicesList.Add(serviceItem);
            }
            return View(servicesList);
        }
        public IActionResult ServiceDetails(int ServiceCode)
        {
            //if (HttpContext.Session.GetString("lang") != null)
            //{
            //    lang = HttpContext?.Session.GetString("lang") ?? "ar";
            //}

            var service = _db.Service.Find(ServiceCode);
            if (service == null)
                return View("Error");

            var serviceSpecialized = _db.ServiceSpecializedService.Where(c => c.ServiceId == ServiceCode).ToList();
            List<SpecializedService> specializedServiceList = new List<SpecializedService>();

            foreach(var specializedServiceId in serviceSpecialized)
            {
                var specializedService = _db.SpecializedService.Find(specializedServiceId.SpecializedServiceId);
                specializedServiceList.Add(specializedService);
            }

            ServiceDetailsViewModel serviceItem = new ServiceDetailsViewModel()
            {
                ServiceName = lang == "ar" ? service.ServiceNameA : service.ServiceNameE,
                ServiceBrief = lang == "ar" ? service.ServiceBriefA : service.ServiceBriefE,
                ServiceOverview = lang == "ar" ? service.ServiceOverviewA : service.ServiceOverviewE,
                ServiceLogo = service.ServiceLogo,
                ServicePhotoPath = service.ServicePhotoPath,
                SpecializedService = specializedServiceList
            };
            
            return View(serviceItem);
        }
    }
}
