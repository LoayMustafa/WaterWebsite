using Microsoft.AspNetCore.Mvc;
using WATERWebsite.Core.ViewModels.BlogViewModels;
using WATERWebsite.Presistance;

namespace WATERWebsite.Controllers
{
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _db;
        private string lang = "en";

        public BlogController(ApplicationDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            lang = HttpContext?.Session.GetString("lang") ?? "en";

            var blogs = _db.Blog.Select(c => new BlogIndexViewModel
            {
                BlogCode = c.BlogCode,
                BlogTitle = lang == "ar" ? c.BlogTitleA : c.BlogTitleE,
                BlogBrief = lang == "ar" ? c.BlogBriefA : c.BlogBriefE,
                BlogContent = lang == "ar" ? c.BlogContentA : c.BlogContentE,
                BlogPublisher = lang == "ar" ? c.BlogPublisherA : c.BlogPublisherE,
                BlogDate = c.BlogDate.ToString("dd/MM/yyyy"),
                BlogPhoto = c.BlogPhotoPath

            }).ToList();
            return View(blogs);
        }
        public IActionResult BlogDetails(int BlogCode)
        {
            lang = HttpContext?.Session.GetString("lang") ?? "en";

            var blog = _db.Blog.Find(BlogCode);
            if (blog == null)
                return NotFound();

            BlogIndexViewModel blogDetails = new BlogIndexViewModel
            {
                BlogCode = blog.BlogCode,
                BlogTitle = lang == "ar" ? blog.BlogTitleA : blog.BlogTitleE,
                BlogBrief = lang == "ar" ? blog.BlogBriefA : blog.BlogBriefE,
                BlogContent = lang == "ar" ? blog.BlogContentA : blog.BlogContentE,
                BlogPublisher = lang == "ar" ? blog.BlogPublisherA : blog.BlogPublisherE,
                BlogDate = blog.BlogDate.ToString("dd/MM/yyyy"),
                BlogPhoto = blog.BlogPhotoPath
            };
            return View(blogDetails);
        }

    }
}
