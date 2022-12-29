using WATERWebsite.Core.DTOs.ProjectDtos;
using WATERWebsite.Core.DTOs.ServiceDtos;

namespace WATERWebsite.Core.ViewModels.HomeViewModels
{
    public class HomeIndexViewModel
    {
        public List<ServicesDto>? ServicesDto { get; set; }
        public List<ProjectHomeDto>? ProjectHomeDto { get; set; }

    }
}
