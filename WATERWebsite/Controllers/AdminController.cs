using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WATERWebsite.Core.DTOs.ProjectDtos;
using WATERWebsite.Core.DTOs.ServiceDtos;
using WATERWebsite.Core.Models;
using WATERWebsite.Core.ViewModels;
using WATERWebsite.Presistance;

namespace WATERWebsite.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private string lang = "ar";

        public AdminController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _db = context;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return NotFound();
            //AdminIndexViewModel viewModel = new AdminIndexViewModel
            //{
            //    Services = new SelectList(_db.Service.ToList(), "ServiceCode", lang == "ar" ? "ServiceNameA" : "ServiceNameE"),
            //};
            //return View(viewModel);
        }

        #region Service
        [HttpGet]
        public IActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateService(CreateServiceDto dto)
        {
            Service service = new Service
            {
                ServiceNameE = dto.ServiceNameE,
                ServiceNameA = dto.ServiceNameA,
                ServiceBriefA = dto.ServiceBriefA,
                ServiceBriefE = dto.ServiceBriefE,
                ServiceOverviewA = dto.ServiceOverviewA,
                ServiceOverviewE = dto.ServiceOverviewE,
            };
            _db.Service.Add(service);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        #endregion

        #region Service Detail
        [HttpPost]
        public IActionResult CreateServiceDetail(CreateServiceDetailItemDto dto)
        {
            ServiceDetail ServiceDetail = new ServiceDetail
            {
                ServiceDetailNameE = dto.ServiceDetailNameE,
                ServiceDetailNameA = dto.ServiceDetailNameA,
                ServiceDetailBriefE = dto.ServiceDetailBriefE,
                ServiceDetailBriefA = dto.ServiceDetailBriefA,
                ServiceDetailOverviewE = dto.ServiceDetailOverviewE,
                ServiceDetailOverviewA = dto.ServiceDetailOverviewA,
                ServiceDetailEndE = dto.ServiceDetailEndE,
                ServiceDetailEndA = dto.ServiceDetailEndA
            };
            _db.ServiceDetail.Add(ServiceDetail);
            _db.SaveChanges();

            return Json(new { success = true });
        }
        #endregion
        [HttpPost]
        public IActionResult CreateSpecific(CreateSpecificDto dto)
        {

            Specifics specifics = new Specifics
            {
                SpecificsNameE = dto.SpecificNameE,
                SpecificsNameA = dto.SpecificNameA,
                SpecificsBriefE = dto.SpecificBriefE,
                SpecificsBriefA = dto.SpecificBriefA,
                SpecificsOverviewE = dto.SpecificOverviewE,
                SpecificsOverviewA = dto.SpecificOverviewA,
                SpecificsEndE = dto.SpecificEndE,
                SpecificsEndA = dto.SpecificEndA
            };
            _db.Specifics.Add(specifics);
            try
            {

                _db.SaveChanges();
            }
            catch(Exception ex)
            {
                var dd = ex.Data;
            }

            return Json(new { success = true }); ;
        }
    }
}
