using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using WaterClassLibrary.Core.Models;
using WATERWebsite.Core.ViewModels.DepartmentViewModels;
using WaterClassLibrary.Presistance;

namespace WATERWebsite.Controllers
{
    public class DepartmentController : Controller
    {
        private string lang = "en";
        private readonly ApplicationDbContext _db;
        private IWebHostEnvironment _webHostEnvironment;

        private List<string> _allowedExe = new() { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
        private int _maxSize = 5242880;
        public DepartmentController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _db = context;
            _webHostEnvironment = webHostEnvironment;
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
            var allDepartments = GetAllDepartments(DepartmentCode);

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
                DepartmentPhotoPath = department.DepartmentPhotoPath,
                ServicesList = departmentServicesList,
                DepartmentsList = allDepartments
            };
            return View(departmentDetail);
        }
        public List<DeprtmentIndexViewModel> GetAllDepartments(int DepartmentCode)
        {
            lang = HttpContext?.Session.GetString("lang") ?? "en";

            var department = _db.Department.Find(DepartmentCode);
            var allDepartments = new List<DeprtmentIndexViewModel>();
            if (department != null)
                allDepartments = _db.Department.Where(c => c.DepartmentCode != DepartmentCode).Select(c => new DeprtmentIndexViewModel
                {
                    DepartmentCode = c.DepartmentCode,
                    DepartmentName = lang == "ar" ? c.DepartmentNameA : c.DepartmentNameE,
                    DepartmentBrief = lang == "ar" ? c.DepartmentBriefA : c.DepartmentBriefE,
                    DepartmentLogoPath = c.DepartmentLogoPath,
                    DepartmentPhotoPath = c.DepartmentPhotoPath,
                }).ToList();
            return allDepartments;
        }
        
        [Authorize]
        public IActionResult Departments()
        {
            var departments = _db.Department.Select(c => new DeprtmentIndexViewModel
            {
                DepartmentCode = c.DepartmentCode,
                DepartmentName = c.DepartmentNameE,
                DepartmentBrief = c.DepartmentBriefE,
                DepartmentLogoPath = c.DepartmentLogoPath,
                DepartmentPhotoPath = c.DepartmentPhotoPath,
                DepartmentEndE = c.DepartmentEndE,
                DepartmentOverviewE = c.DepartmentOverviewE,
                HomeDescA = c.HomeDescA
            }).ToList();

            return View(departments);
        }
        [HttpGet]
        public IActionResult AddDepartment(int? DepartmentCode)
        {
            var model = new DepartmentActionViewModel();
            var services = new SelectList(_db.Service.ToList(), "ServiceCode", "ServiceNameE");
            model.Services = services;
            if (DepartmentCode != null)
            {
                var department = _db.Department.Find(DepartmentCode);
                if (department != null)
                {
                    model = new DepartmentActionViewModel
                    {
                        DepartmentCode = department.DepartmentCode,
                        DepartmentNameE = department.DepartmentNameE,
                        DepartmentNameA = department.DepartmentNameA,
                        DepartmentOverviewE = department.DepartmentOverviewE,
                        DepartmentOverviewA = department.DepartmentOverviewA,
                        DepartmentBriefE = department.DepartmentBriefE,
                        DepartmentBriefA = department.DepartmentBriefA,
                        DepartmentEndE = department.DepartmentEndE,
                        DepartmentEndA = department.DepartmentEndA,
                        HomeDescA = department.HomeDescA,
                        HomeDescE = department.HomeDescE,
                        DepartmentPhotoPath = department.DepartmentPhotoPath,
                        Services = services,
                    };
                }
            }
            return PartialView("_AddDepartmentPartial", model);
        }
        [HttpPost]
        public IActionResult AddDepartment(DepartmentActionViewModel viewModel)
        {
            var imageName = "9d742109-84d3-4021-90d5-0d3d84de2c0d.png";

            if (viewModel.PhotoFile is not null)
            {
                var extension = Path.GetExtension(viewModel.PhotoFile.FileName);
                if (!_allowedExe.Contains(extension))
                {
                    ModelState.AddModelError(nameof(viewModel.PhotoFile), "Not Allowed Extension, only allowed is(.jpg,.jpe,.png,.gif,.webp)");
                }
                if (viewModel.PhotoFile.Length > _maxSize)
                {
                    ModelState.AddModelError(nameof(viewModel.PhotoFile), "Photo Size Is too large, max is 5.0MB");
                }

                imageName = $"{Guid.NewGuid()}{extension}";

                var path = Path.Combine($"{_webHostEnvironment.WebRootPath}/resourses/departments", imageName);

                using var stream = System.IO.File.Create(path);
                viewModel.PhotoFile.CopyTo(stream);
            }
            var services = new List<Service>();
            if (viewModel.ServiceCodes != null)
            {
                if (viewModel.ServiceCodes.Count > 0)
                    services = _db.Service.Where(c => viewModel.ServiceCodes.Contains(c.ServiceCode)).ToList();
            }
            if (!ModelState.IsValid)
                return PartialView("_AddDepartmentPartial", viewModel);
            if (viewModel.DepartmentCode != 0)
            {
                var department = _db.Department.Find(viewModel.DepartmentCode);
                if (department != null)
                {
                    department.DepartmentCode = viewModel.DepartmentCode;
                    department.DepartmentNameE = viewModel.DepartmentNameE;
                    department.DepartmentNameA = viewModel.DepartmentNameA;
                    department.DepartmentOverviewE = viewModel.DepartmentOverviewE;
                    department.DepartmentOverviewA = viewModel.DepartmentOverviewA;
                    department.DepartmentBriefE = viewModel.DepartmentBriefE;
                    department.DepartmentBriefA = viewModel.DepartmentBriefA;
                    department.DepartmentEndE = viewModel.DepartmentEndE;
                    department.DepartmentEndA = viewModel.DepartmentEndA;
                    department.HomeDescA = viewModel.HomeDescA;
                    department.HomeDescE = viewModel.HomeDescE;
                    department.DepartmentPhotoPath = imageName;
                    department.Services = services;
                }
            }
            else
            {
                Department record = new Department
                {
                    DepartmentCode = viewModel.DepartmentCode,
                    DepartmentNameE = viewModel.DepartmentNameE,
                    DepartmentNameA = viewModel.DepartmentNameA,
                    DepartmentOverviewE = viewModel.DepartmentOverviewE,
                    DepartmentOverviewA = viewModel.DepartmentOverviewA,
                    DepartmentBriefE = viewModel.DepartmentBriefE,
                    DepartmentBriefA = viewModel.DepartmentBriefA,
                    DepartmentEndE = viewModel.DepartmentEndE,
                    DepartmentEndA = viewModel.DepartmentEndA,
                    HomeDescA = viewModel.HomeDescA,
                    HomeDescE = viewModel.HomeDescE,
                    DepartmentPhotoPath = imageName,
                    Services = services
                };
                _db.Department.Add(record);
            }
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteDepartment(int DepartmentCode)
        {
            var department = _db.Department.Find(DepartmentCode);
            if (department != null)
            {
                _db.Department.Remove(department);
                _db.SaveChanges();
                return Json(new { success = true, msg = "Deleted Successfully" });
            }
            return Json(new { success = false });
        }
    }
}
