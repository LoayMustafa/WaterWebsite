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
            AdminIndexViewModel viewModel = new AdminIndexViewModel
            {
                Services = new SelectList(_db.Service.ToList(), "ServiceCode", lang == "ar" ? "ServiceNameA" : "ServiceNameE"),
                Projects = new SelectList(_db.Project.ToList(), "ProjectCode", lang == "ar" ? "ProjectNameA" : "ProjectNameE"),
            };
            return View(viewModel);
        }

        #region Service
        [HttpGet]
        public IActionResult CreateProject()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProject(CreateProjectDto dto)
        {
            string dbPath = "~/Resourses/Projects/projects-default.jpg";
            if (dto.Photo != null)
            {
                string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Resourses", "Projects");
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }
                var fileName = Guid.NewGuid().ToString() + "_" + dto.Photo.FileName;
                var filePath = Path.Combine(uploadFolder, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    dto.Photo.CopyTo(stream);
                }
                dbPath = "~/Resourses/Projects/" + fileName;
            }
            Project project = new Project
            {
                ProjectNameE = dto.ProjectNameE,
                ProjectNameA = dto.ProjectNameA,
                ProjectDeveloperA = dto.ProjectDeveloperA,
                ProjectDeveloperE = dto.ProjectDeveloperE,
                ProjectOverviewE = dto.ProjectOverviewE,
                ProjectOverviewA = dto.ProjectOverviewA,
                ProjectLocationA = dto.ProjectLocationA,
                ProjectLocationE = dto.ProjectLocationE,
                ProjectOperatorA = dto.ProjectOperatorA,
                ProjectOperatorE = dto.ProjectOperatorE,
                ProjectOwnerA = dto.ProjectOwnerA,
                ProjectOwnerE = dto.ProjectOwnerE,
                ProjectDate = dto.ProjectDate,
                ProjectCapacity = dto.ProjectCapacity,
                ProjectPhotoPath = dbPath,
            };

            return Json(new { success = true });
        }
        #endregion

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
    }
}
