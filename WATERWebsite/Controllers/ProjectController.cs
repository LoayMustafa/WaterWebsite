using Microsoft.AspNetCore.Mvc;
using WATERWebsite.Core.DTOs.ProjectDtos;
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

        public IActionResult ProjectDetails(int ProjectCode)
        {
            lang = HttpContext?.Session.GetString("lang") ?? "en";

            //Get Project
            var project = _db.Projects.Find(ProjectCode);
            if (project == null)
                return NotFound();

            var projectSpecifics = _db.ProjectSpecific.Where(c => c.ProjectCode == ProjectCode);
            List <ProjectSpecificsDto> projectSpecificsList = new List<ProjectSpecificsDto>();
            if(projectSpecifics.Count() != 0)
            {
                foreach (var specifics in projectSpecifics)
                {
                    var specific = _db.Specifics.Find(specifics.SpecificCode);
                    ProjectSpecificsDto specificsDto = new ProjectSpecificsDto()
                    {
                        SpecificCode = specifics.SpecificCode,
                        SpecificName = specific?.SpecificsNameE
                    };
                    projectSpecificsList.Add(specificsDto);
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
                ProjectPhotoPath = project.ProjectPhotoPath,
                ProjectCost = project.ProjectCost,
                ProjectSpecificsDto = projectSpecificsList
            };
            return View(viewModel);
        }
    }
}
