using WATERWebsite.Core.DTOs.BlogDtos;
using WATERWebsite.Core.DTOs.ProjectDtos;
using WATERWebsite.Core.DTOs.ServiceDtos;

namespace WATERWebsite.Core.ViewModels.HomeViewModels
{
    public class HomeIndexViewModel
    {
        public List<DepartmentsHomeDto>? DepartmentsDto { get; set; }
        public List<ProjectHomeDto>? ProjectHomeDto { get; set; }
        public List<BlogHomeDto>? BlogHomeDto { get; set; }

    }
}
