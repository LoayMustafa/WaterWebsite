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
            //Get Projects
            var projects = _db.Project.Select(c => new ProjectIndexViewModel
            {
                ProjectCode = c.ProjectCode,
                ProjectName = lang == "ar" ? c.ProjectNameA : c.ProjectNameE,
                ProjectLocation = lang == "ar" ? c.ProjectLocationA : c.ProjectLocationE,
                ProjectPhotoPath = c.ProjectPhotoPath
            }).ToList();

            return View(projects);
        }

        public IActionResult ProjectDetails(int ProjectCode)
        {
            //Get Project
            var project = _db.Project.Find(ProjectCode);
            if (project == null)
                return NotFound();

            //Get Project Service Items
            //var projectServItems = _db.ProjectsServiceItems.Where(c => c.ProjectId == ProjectCode);

            //List<ProjectServiceItemsDto> projectServiceItemsList = new List<ProjectServiceItemsDto>();
            //if (projectServItems != null)
            //{
            //    foreach (var item in projectServItems)
            //    {
            //        var service = _db.ServiceItem.Find(item.ServiceItemId);
            //        if (service != null)
            //        {
            //            ProjectServiceItemsDto projectServiceItem = new ProjectServiceItemsDto()
            //            {
            //                ServiceName = lang == "ar" ? service.ServiceItemNameA : service.ServiceItemNameE,
            //            };
            //            projectServiceItemsList.Add(projectServiceItem);
            //        }

            //    }
            //}

            ProjectDetailsViewModel viewModel = new ProjectDetailsViewModel
            {
                ProjectName = lang == "ar" ? project.ProjectNameA : project.ProjectNameE,
                ProjectLocation = lang == "ar" ? project.ProjectLocationA : project.ProjectLocationE,
                ProjectCapacity = project.ProjectCapacity,
                ProjectDeveloper = lang == "ar" ? project.ProjectDeveloperA : project.ProjectDeveloperE,
                ProjectOwner = lang == "ar" ? project.ProjectOwnerA : project.ProjectOwnerE,
                ProjectOverview = lang == "ar" ? project.ProjectOverviewA : project.ProjectOverviewE,
                ProjectOperator = lang == "ar" ? project.ProjectOperatorA : project.ProjectOperatorE,
                ProjectPhotoPath = project.ProjectPhotoPath,
                ProjectDate = project.ProjectDate.ToString("dd/MM/yyyy"),
                //ProjectServiceItemsDto = projectServiceItemsList
            };
            return View(viewModel);
        }
    }
}
