using Microsoft.AspNetCore.Mvc;
using WATERWebsite.Core.DTOs.ProjectDtos;
using WATERWebsite.Core.Models;
using WATERWebsite.Core.ViewModels.ProjectViewModels;
using WATERWebsite.Presistance;

namespace WATERWebsite.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _db;
        private string lang = "en";

        public ProjectController(ApplicationDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            lang = HttpContext?.Session.GetString("lang") ?? "en";

            //Get Projects
            var projects = _db.Projects.Select(c => new ProjectIndexViewModel
            {
                ProjectCode = c.ProjectCode,
                ProjectName = lang == "ar" ? c.ProjectNameA : c.ProjectNameE,
                ProjectLocation = lang == "ar" ? c.ProjectLocationA : c.ProjectLocationE,
                ProjectPhotoPath = c.ProjectPhotoPath,
            }).ToList();

            return View(projects);
        }

        [HttpGet("/Project/ProjectDetails/{ProjectCode}")]
        public IActionResult ProjectDetails(int ProjectCode)
        {
            lang = HttpContext?.Session.GetString("lang") ?? "en";

            //Get Project
            var project = _db.Projects.Find(ProjectCode);
            if (project == null)
                return NotFound();

            var projectServices = _db.ProjectService.Where(c => c.ProjectCode == ProjectCode);
            List <ProjectServicesDto> projectSpecificsList = new List<ProjectServicesDto>();
            if(projectServices.Count() != 0)
            {
                foreach (var services in projectServices)
                {
                    var service = _db.Service.Find(services.ServiceCode);
                    if (service != null)
                    {
                        ProjectServicesDto servicesDto = new ProjectServicesDto()
                        {
                            ServiceCode = service.ServiceCode,
                            ServiceName = lang == "ar" ? service?.ServiceNameA : service?.ServiceNameE
                        };
                        projectSpecificsList.Add(servicesDto);
                    }
                }
            }

            ProjectDetailsViewModel viewModel = new ProjectDetailsViewModel
            {
                ProjectName = lang == "ar" ? project.ProjectNameA : project.ProjectNameE,
                ProjectLocation = lang == "ar" ? project.ProjectLocationA : project.ProjectLocationE,
                ProjectCapacity = project.ProjectCapacity,
                ProjectOwner = lang == "ar" ? project.ProjectOwnerA : project.ProjectOwnerE,
                ProjectOverview = lang == "ar" ? project.ProjectOverviewA : project.ProjectOverviewE,
                ProjectOperator = lang == "ar" ? project.ProjectOperatorA : project.ProjectOperatorE,
                ProjectPhotoPath = project.ProjectPhotoPath != null ? $"{Request.Scheme}://{Request.Host}/{project.ProjectPhotoPath?.TrimStart('/')}" : null,
                ProjectCost = project.ProjectCost,
                ProjectSpecificsDto = projectSpecificsList
            };
            return View(viewModel);
        }
    }
}
