using Microsoft.AspNetCore.Mvc;
using WATERWebsite.Core.ViewModels.EmployeeViewModels;
using WATERWebsite.Presistance;

namespace WATERWebsite.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private string lang = "en";

        public EmployeeController(ApplicationDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            lang = HttpContext?.Session.GetString("lang") ?? "en";

            var emplyees = _db.Employee.Select(c => new EmployeeIndexViewModel
            {
                EmployeeCode = c.EmployeeCode,
                EmployeeName = lang == "ar" ? c.EmployeeNameA : c.EmployeeNameE,
                EmployeeJob = lang == "ar" ? c.EmployeeJobA : c.EmployeeJobE,
                EmployeeDescription = lang == "ar" ? c.EmployeeDescriptionA : c.EmployeeDescriptionE,
                EmployeePhotoPath = c.EmployeePhotoPath,
                EmployeePhone = c.EmployeePhone,
                EmployeeEmail = c.EmployeeEmail,
                IsKey = c.IsKey
            }).ToList();
            return View(emplyees);
        }
        public IActionResult EmpolyeeDetails(int EmployeeCode)
        {
            lang = HttpContext?.Session.GetString("lang") ?? "en";

            var employee = _db.Employee.Find(EmployeeCode);
            if (employee == null)
                return NotFound();

            EmployeeDetailsViewModel viewModel = new EmployeeDetailsViewModel()
            {
                EmployeeName = lang == "ar" ? employee.EmployeeNameA : employee.EmployeeNameE,
                EmployeeJob = lang == "ar" ? employee.EmployeeJobA : employee.EmployeeJobE,
                EmployeeDescription = lang == "ar" ? employee.EmployeeDescriptionA : employee.EmployeeDescriptionE,
                EmployeeEmail = employee.EmployeeEmail,
                EmployeePhone = employee.EmployeePhone,
                EmployeePhotoPath = employee.EmployeePhotoPath,
            };

            return View(viewModel);
        }
    }
}
