using AutoMapper;
using MyProject.DAL;
using MyProject.DTO.Common;

namespace MyProject.DTO.AutoMapperProfiles
{
    public class AutoMapperProfileDTO : Profile
    {
        public AutoMapperProfileDTO()
        {
            CreateMap<IVehicleMakeDTO, VehicleMake>().ReverseMap();
            CreateMap<IVehicleModelDTO, VehicleModel>().ReverseMap();
        }
    }
}
