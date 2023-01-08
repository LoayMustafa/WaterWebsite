using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WATERWebsite.Core.DTOs;
using WATERWebsite.Core.Models;
using WATERWebsite.Core.ViewModels;
using WATERWebsite.Presistance;

namespace WATERWebsite.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;
        private string lang = "en";

        public AdminController(ApplicationDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            AdminIndexViewModel viewModel = new AdminIndexViewModel
            {
                Services = new SelectList(_db.Service.ToList(), "ServiceCode", lang == "ar" ? "ServiceNameA" : "ServiceNameE"),
                Projects = new SelectList(_db.Project.ToList(), "ProjectCode", lang == "ar" ? "ProjectNameA" : "ProjectNameE"),
                Divisions = new SelectList(_db.Division.ToList(), "DivisionCode", lang == "ar" ? "DivisionNameA" : "DivisionNameE"),
                SubServices = new SelectList(_db.SubService.ToList(), "SubServiceCode", lang == "ar" ? "SubServiceNameA" : "SubServiceNameE"),
            };
            return View(viewModel);
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

            if (dto.ProjectCodes != null)
            {
                var projects = _db.Project.Where(c => dto.ProjectCodes.Contains(c.ProjectCode)).ToList();
                foreach (var project in projects)
                {
                    ProjectServices projectService = new ProjectServices
                    {
                        ServiceCode = service.ServiceCode,
                        ProjectCode = project.ProjectCode,
                    };
                    _db.ProjectServices.Add(projectService);
                }
            }
            if(dto.DivisionCodes != null)
            {
                var divisions = _db.Division.Where(c => dto.DivisionCodes.Contains(c.DivisionCode)).ToList();
                foreach (var division in divisions)
                {
                    ServiceDivisons serviceDivision = new ServiceDivisons
                    {
                        ServiceCode = service.ServiceCode,
                        DivisionCode = division.DivisionCode,
                    };
                    _db.ServiceDivisons.Add(serviceDivision);
                }
            }

            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion
    }
}
