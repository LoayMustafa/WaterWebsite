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
            var empolyees = _db.Employee.Select(c => new AboutUsTeamViewModel
            {
                EmpolyeeName = lang == "ar" ? c.EmployeeNameA : c.EmployeeNameE,
                EmpolyeeJob = lang == "ar" ? c.EmployeeJobA : c.EmployeeJobE,
                EmpolyeeDescription = c.EmployeeDescription,
            }).ToList();

            return View(empolyees);
        }
    }
}
