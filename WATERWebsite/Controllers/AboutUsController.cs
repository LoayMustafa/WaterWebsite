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
            lang = HttpContext?.Session.GetString("lang") ?? "en";
            //Get Employees
            var employees = _db.Employee.Where(c => c.EmployeeLevel == 1 || c.EmployeeLevel == 2).Select(c => new AboutUsTeamViewModel
            {
                EmployeeCode = c.EmployeeCode,
                EmployeeName = lang == "ar" ? c.EmployeeNameA : c.EmployeeNameE,
                EmployeeJob = lang == "ar" ? c.EmployeeJobA : c.EmployeeJobE,
                EmployeeBio = lang == "ar" ? c.EmployeeBioA : c.EmployeeBioE,
                EmployeePhotoPath = c.EmployeePhotoPath
            }).ToList();

            return View(employees);
        }
    }
}
