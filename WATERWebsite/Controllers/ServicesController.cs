using Microsoft.AspNetCore.Mvc;
using WATERWebsite.Core.DTOs;
using WATERWebsite.Core.DTOs.ServiceDtos;
using WATERWebsite.Core.Models;
using WATERWebsite.Core.ViewModels;
using WATERWebsite.Core.ViewModels.DepartmentViewModels;
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

        [HttpGet("/Services/ServiceDetails/{ServiceCode}")]
        public IActionResult ServiceDetails(int ServiceCode)
        {
            lang = HttpContext?.Session.GetString("lang") ?? "en";

            var service = _db.Service.Find(ServiceCode);
            if (service == null)
                return NotFound();
            var allServices = GetAllServices(ServiceCode);

            List<ServiceDetailsDto> serviceDetailsList = new List<ServiceDetailsDto>();
            var serviceDetail = _db.ServiceDetail.Where(c => c.ServiceCode == ServiceCode).ToList();
            if (serviceDetail?.Count > 0)
            {
                foreach (var item in serviceDetail)
                {
                    var specifics = _db.Specifics.Where(c => c.ServiceDetailCode == item.ServiceDetailCode);
                    ServiceDetailsDto serviceDetailItem = new ServiceDetailsDto()
                    {
                        ServiceDetailCode = item.ServiceDetailCode,
                        ServiceDetailName = lang == "ar" ? item.ServiceDetailNameA : item.ServiceDetailNameE,
                        ServiceDetailBrief = lang == "ar" ? item.ServiceDetailBriefA : item.ServiceDetailBriefE,
                        ServiceDetailOverview = lang == "ar" ? item.ServiceDetailOverviewA : item.ServiceDetailOverviewE,
                        ServiceDetailEnd = lang == "ar" ? item.ServiceDetailEndA : item.ServiceDetailEndE,
                        IsClickable = specifics.Count() != 0 || item.ServiceDetailOverviewE != null
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
                ServicePhotoPath = $"{Request.Scheme}://{Request.Host}/{service.ServicePhotoPath?.TrimStart('/')}",
                ServiceEnd = lang == "ar" ? service.ServiceEndA : service.ServiceEndE,
                ServiceDetails = serviceDetailsList,
                ServiceList = allServices,
            };
            return View(serviceItem);
        }

        [HttpGet("/Services/ServiceDetailItem/{ServiceDetailCode}")]
        public IActionResult ServiceDetailItem(int ServiceDetailCode)
        {
            lang = HttpContext?.Session.GetString("lang") ?? "en";

            var serviceDetail = _db.ServiceDetail.Find(ServiceDetailCode);
            if (serviceDetail == null)
                return NotFound();

            List<ServiceDetailSpecificsDto> specificsList = new List<ServiceDetailSpecificsDto>();
            var specific = _db.Specifics.Where(c => c.ServiceDetailCode == serviceDetail.ServiceDetailCode).ToList();
            foreach (var item in specific)
            {
                ServiceDetailSpecificsDto specificItem = new ServiceDetailSpecificsDto()
                {
                    SpecificCode = item.SpecificsCode,
                    SpecificName = lang == "ar" ? item.SpecificsNameA : item.SpecificsNameE,
                    SpecificBrief = lang == "ar" ? item.SpecificsBriefA : item.SpecificsBriefE,
                    SpecificOverView = lang == "ar" ? item.SpecificsOverviewE : item.SpecificsOverviewA,
                };
                specificsList.Add(specificItem);
            }

            List<ServiceDetailsDto> serviceDetailsList = new List<ServiceDetailsDto>();
            var service = _db.Service.FirstOrDefault(c => c.ServiceCode == serviceDetail.ServiceCode);
            if (service != null)
            {
                var serviceDetailList = _db.ServiceDetail.Where(c => c.ServiceCode == service.ServiceCode && c.ServiceDetailCode != ServiceDetailCode).ToList();
                if (serviceDetailList?.Count > 0)
                {
                    foreach (var item in serviceDetailList)
                    {
                        var specifics = _db.Specifics.Where(c => c.ServiceDetailCode == item.ServiceDetailCode);
                        ServiceDetailsDto servDetail = new ServiceDetailsDto()
                        {
                            ServiceDetailCode = item.ServiceDetailCode,
                            ServiceDetailName = lang == "ar" ? item.ServiceDetailNameA : item.ServiceDetailNameE,
                            ServiceDetailBrief = lang == "ar" ? item.ServiceDetailBriefA : item.ServiceDetailBriefE,
                            ServiceDetailOverview = lang == "ar" ? item.ServiceDetailOverviewA : item.ServiceDetailOverviewE,
                            ServiceDetailEnd = lang == "ar" ? item.ServiceDetailEndA : item.ServiceDetailEndE,
                            IsClickable = specifics.Count() != 0 || item.ServiceDetailOverviewE != null
                        };
                        serviceDetailsList.Add(servDetail);
                    }
                }
            }


            ServiceDetailsDto serviceDetailItem = new ServiceDetailsDto()
            {
                ServiceDetailCode = serviceDetail.ServiceDetailCode,
                ServiceDetailName = lang == "ar" ? serviceDetail.ServiceDetailNameA : serviceDetail.ServiceDetailNameE,
                ServiceDetailBrief = lang == "ar" ? serviceDetail.ServiceDetailBriefA : serviceDetail.ServiceDetailBriefE,
                ServiceDetailOverview = lang == "ar" ? serviceDetail.ServiceDetailOverviewA : serviceDetail.ServiceDetailOverviewE,
                ServiceDetailEnd = lang == "ar" ? serviceDetail.ServiceDetailEndA : serviceDetail.ServiceDetailEndE,
                ServiceDetailSpecifics = specificsList,
                ServiceDetailList = serviceDetailsList
            };

            return View(serviceDetailItem);
        }

        [HttpGet("/Services/SpecificDetail/{SpecificsCode}")]
        public IActionResult SpecificDetail(int SpecificsCode)
        {
            lang = HttpContext?.Session.GetString("lang") ?? "en";

            var specific = _db.Specifics.Find(SpecificsCode);
            if (specific == null)
                return NotFound();


            List<ServiceDetailSpecificsDto> specificsList = new List<ServiceDetailSpecificsDto>();
            var specificList = _db.Specifics.Where(c => c.ServiceDetailCode == specific.ServiceDetailCode && c.SpecificsCode != SpecificsCode).ToList();
            foreach (var item in specificList)
            {
                ServiceDetailSpecificsDto specificItem = new ServiceDetailSpecificsDto()
                {
                    SpecificCode = item.SpecificsCode,
                    SpecificName = lang == "ar" ? item.SpecificsNameA : item.SpecificsNameE,
                    SpecificBrief = lang == "ar" ? item.SpecificsBriefA : item.SpecificsBriefE,
                    SpecificOverView = lang == "ar" ? item.SpecificsOverviewE : item.SpecificsOverviewA,
                };
                specificsList.Add(specificItem);
            }

            SpecificDetailViewModel viewModel = new SpecificDetailViewModel()
            {
                SpecificsName = lang == "ar" ? specific.SpecificsNameA : specific.SpecificsNameE,
                SpecificsBrief = lang == "ar" ? specific.SpecificsBriefA : specific.SpecificsBriefE,
                SpecificsOverview = lang == "ar" ? specific.SpecificsOverviewA : specific.SpecificsOverviewE,
                SpecificsEnd = lang == "ar" ? specific.SpecificsEndA : specific.SpecificsEndE,
                SpecificsList = specificsList
            };

            return View(viewModel);
        }
        public List<ServicesIndexViewModel> GetAllServices(int ServiceCode)
        {
            lang = HttpContext?.Session.GetString("lang") ?? "en";

            var service = _db.Service.Find(ServiceCode);
            var allServices = new List<ServicesIndexViewModel>();
            if (service != null)
            {
                var deprtmentServ = _db.Service.Where(c => c.DepartmentCode == service.DepartmentCode).Select(c => c.ServiceCode);
                allServices = _db.Service.Where(c => c.ServiceCode != ServiceCode && deprtmentServ.Contains(c.ServiceCode)).Select(c => new ServicesIndexViewModel
                {
                    ServiceCode = c.ServiceCode,
                    ServiceName = lang == "ar" ? c.ServiceNameA : c.ServiceNameE,
                    ServiceBrief = lang == "ar" ? c.ServiceBriefA : c.ServiceBriefE,
                    ServiceOverview = lang == "ar" ? c.ServiceOverviewA : c.ServiceOverviewE,
                }).ToList();
            }
            return allServices;
        }
    }
}
