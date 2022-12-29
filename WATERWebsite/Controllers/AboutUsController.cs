using Microsoft.AspNetCore.Mvc;
using WATERWebsite.Core.ViewModels.AboutUsViewModels;
using WATERWebsite.Presistance;

namespace WATERWebsite.Controllers
{
    public class AboutUsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private string lang = "en";

        public AboutUsController(ApplicationDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            //Get Employees
            var employees = _db.Employee.Select(c => new AboutUsTeamViewModel
            {
                EmployeeCode = c.EmployeeCode,
                EmployeeName = lang == "ar" ? c.EmployeeNameA : c.EmployeeNameE,
                EmployeeJob = lang == "ar" ? c.EmployeeJobA : c.EmployeeJobE,
                EmployeeDescription = lang == "ar" ? c.EmployeeDescriptionA : c.EmployeeDescriptionE,
                EmployeePhotoPath = c.EmployeePhotoPath
            }).ToList();

            return View(employees);
        }
    }
}
