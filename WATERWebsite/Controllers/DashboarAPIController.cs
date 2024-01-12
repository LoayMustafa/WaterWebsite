using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WaterClassLibrary.Presistance;

namespace WATERWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboarAPIController : ControllerBase
    {
        private IWebHostEnvironment _webHostEnvironment;
        public DashboarAPIController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        [Route("UploadToWebsite")]
        public IActionResult UploadToWebsite([FromForm] IFormFile PhotoFile, [FromForm] string imageName)
        {
            var path = Path.Combine($"{_webHostEnvironment.WebRootPath}/resourses/Blog", imageName);

            using var stream = System.IO.File.Create(path);
            PhotoFile.CopyTo(stream);
            return Ok("sss");
        }
    }
}
