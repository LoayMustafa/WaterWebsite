using Microsoft.AspNetCore.Mvc;
using WATERWebsite.Core.DTOs;
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
            lang = HttpContext?.Session.GetString("lang") ?? "en";

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
            lang = HttpContext?.Session.GetString("lang") ?? "en";

            var service = _db.Service.Find(ServiceCode);
            if (service == null)
                return View("Error");

            List<ServiceDetailsDto> serviceDetailsList = new List<ServiceDetailsDto>();
            var serviceDetail = _db.ServiceDetail.Where(c => c.ServiceCode == ServiceCode).ToList();
            if(serviceDetail?.Count > 0)
            {
                foreach(var item in serviceDetail)
                {
                    ServiceDetailsDto serviceDetailItem = new ServiceDetailsDto()
                    {
                        ServiceDetailCode = item.ServiceDetailCode,
                        ServiceDetailName = lang == "ar" ? item.ServiceDetailNameA : item.ServiceDetailNameE,
                        ServiceDetailBrief = lang == "ar" ? item.ServiceDetailBriefA : item.ServiceDetailBriefE,
                        ServiceDetailOverview = lang == "ar" ? item.ServiceDetailOverviewA : item.ServiceDetailOverviewE,
                        ServiceDetailEnd = lang == "ar" ? item.ServiceDetailEndA : item.ServiceDetailEndE,
                    };
                    serviceDetailsList.Add(serviceDetailItem);
                }
            }

            ServiceDetailsViewModel serviceItem = new ServiceDetailsViewModel()
            {
                ServiceName = lang == "ar" ? service.ServiceNameA : service.ServiceNameE,
                ServiceBrief = lang == "ar" ? service.ServiceBriefA : service.ServiceBriefE,
                ServiceOverview = lang == "ar" ? service.ServiceOverviewA : service.ServiceOverviewE,
                ServiceLogo = service.ServiceLogo,                
                ServicePhotoPath = service.ServicePhotoPath,
                ServiceDetails = serviceDetailsList
            };
            return View(serviceItem);
        }
        
    }
}
