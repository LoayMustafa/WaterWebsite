using Microsoft.AspNetCore.Mvc;
using WATERWebsite.Core.ViewModels.DepartmentViewModels;
using WATERWebsite.Presistance;

namespace WATERWebsite.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _db;
        private string lang = "en";
        
        public DepartmentController(ApplicationDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            lang = HttpContext?.Session.GetString("lang") ?? "en";

            var departments = _db.Department.Select(c => new DeprtmentIndexViewModel
            {
                DepartmentCode = c.DepartmentCode,
                DepartmentName = lang == "ar" ? c.DepartmentNameA : c.DepartmentNameE,
                DepartmentBrief = lang == "ar" ? c.DepartmentBriefA : c.DepartmentBriefE,
                DepartmentLogoPath = c.DepartmentLogoPath,
                DepartmentPhotoPath = c.DepartmentPhotoPath,
            }).ToList();

            return View(departments);
        }

        [HttpGet("/Department/DepartmentDetail/{DepartmentCode}")]
        public IActionResult DepartmentDetail(int DepartmentCode)
        {
            lang = HttpContext?.Session.GetString("lang") ?? "en";

            var department = _db.Department.Find(DepartmentCode);
            if (department == null) 
                return View("Error");

            // Get Department Services
            var deprtmentServ = _db.Service.Where(c => c.DepartmentCode == DepartmentCode).ToList();
            List<DepartmentServiceDto> departmentServicesList = new List<DepartmentServiceDto>();
            if (deprtmentServ.Count > 0)
            {

                foreach (var service in deprtmentServ)
                {
                    DepartmentServiceDto departmentService = new DepartmentServiceDto
                    {
                        ServiceCode = service.ServiceCode,
                        ServiceName = lang == "ar" ? service.ServiceNameA : service.ServiceNameE,
                        ServiceBrief = lang == "ar" ? service.ServiceBriefA : service.ServiceBriefE,
                        ServiceOverview = lang == "ar" ? service.ServiceOverviewA : service.ServiceOverviewE,
                    };
                    departmentServicesList.Add(departmentService);
                }
            }
            // Get Department Detail
            DepartmentDetailViewModel departmentDetail = new DepartmentDetailViewModel
            {
                DepartmentCode = DepartmentCode,
                DepartmentName = lang == "ar" ? department.DepartmentNameA : department.DepartmentNameE,
                DepartmentBrief = lang == "ar" ? department.DepartmentBriefA : department.DepartmentBriefE,
                DepartmentOverview = lang == "ar" ? department.DepartmentOverviewA : department.DepartmentOverviewE,
                DepartmentEnd = lang == "ar" ? department.DepartmentEndA : department.DepartmentEndE,
                DepartmentLogoPath = department.DepartmentLogoPath,
                DepartmentPhotoPath = $"{Request.Scheme}://{Request.Host}/{department.DepartmentPhotoPath?.TrimStart('/')}",
                ServicesList = departmentServicesList
            };
            return View(departmentDetail);
        }
    }
}
