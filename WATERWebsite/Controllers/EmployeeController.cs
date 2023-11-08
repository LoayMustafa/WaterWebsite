using Microsoft.AspNetCore.Mvc;
using WATERWebsite.Core.ViewModels.EmployeeViewModels;
using WaterClassLibrary.Presistance;

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


            var emplyees = _db.Employee.Where(c => c.EmployeeLevel != 0).Select(c => new EmployeeIndexViewModel
            {
                EmployeeCode = c.EmployeeCode,
                EmployeeName = lang == "ar" ? c.EmployeeNameA : c.EmployeeNameE,
                EmployeeJob = lang == "ar" ? c.EmployeeJobA : c.EmployeeJobE,
                EmployeeBio = lang == "ar" ? c.EmployeeBioA : c.EmployeeBioE,
                EmployeePhotoPath = c.EmployeePhotoPath,
                EmployeePhone = c.EmployeePhone,
                EmployeeEmail = c.EmployeeEmail,
                EmployeeLvl = c.EmployeeLevel
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
                EmployeeDescription = lang == "ar" ? employee.EmployeeBioA : employee.EmployeeBioE,
                EmployeeEmail = employee.EmployeeEmail,
                EmployeeLinkedIn = employee.EmployeeLinkedIn,
                EmployeePhone = employee.EmployeePhone,
                EmployeePhotoPath = employee.EmployeePhotoPath,
            };

            return PartialView("_EmpolyeeDetailsPartial", viewModel);
        }
    }
}
