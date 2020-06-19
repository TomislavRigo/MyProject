using AutoMapper;
using MyProject.DAL;
using MyProject.DTO.Common;

namespace MyProject.WebApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<VehicleMake, IVehicleMakeDTO>().ReverseMap();
            CreateMap<VehicleModel, IVehicleModelDTO>().ReverseMap();
        }
    }
}
