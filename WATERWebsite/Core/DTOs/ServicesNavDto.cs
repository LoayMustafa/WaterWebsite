using WATERWebsite.Core.DTOs.ServiceDtos;

namespace WATERWebsite.Core.DTOs
{
    public class ServicesNavDto
    {
        public List<DepartmentNavDto>? Departments { get; set; }
        public List<ServiceNavDto>? Services { get; set; }
        public List<ServiceDetailDto>? ServiceDetails { get; set; }
    }
}
