using Microsoft.AspNetCore.Mvc.Rendering;
using WATERWebsite.Core.Models;

namespace WATERWebsite.Core.ViewModels
{
    public class AdminIndexViewModel
    {
        public SelectList? Services { get; set; }
        public SelectList? Projects { get; set; }
        public SelectList? Divisions { get; set; }
        public SelectList? SubServices { get; set; }
    }
}
