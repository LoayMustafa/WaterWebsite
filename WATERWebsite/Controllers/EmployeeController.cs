using Microsoft.AspNetCore.Mvc;
using WATERWebsite.Core.ViewModels.EmployeeViewModels;
using WATERWebsite.Presistance;

namespace WATERWebsite.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private string lang = "en";

        public EmployeeController(ILogger<HomeController> logger, IWebHostEnvironment hostingEnvironment, ApplicationDbContext context)
        {
            _db = context;
        }
        public IActionResult EmpolyeeDetails(int EmployeeCode)
        {
            //Get Employee

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
