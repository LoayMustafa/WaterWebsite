using Microsoft.AspNetCore.Mvc;

namespace WATERWebsite.Controllers
{
    public class Dashboard : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
