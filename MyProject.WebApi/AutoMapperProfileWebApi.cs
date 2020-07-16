using AutoMapper;
using MyProject.DTO.Common;
using MyProject.WebApi.Models;

namespace MyProject.AutoMapperProfilesWebApi
{
    public class AutoMapperProfileWebApi : Profile
    {
        public AutoMapperProfileWebApi()
        {
            CreateMap<IVehicleMakeDTO, QueryParams>().ReverseMap();
            CreateMap<IVehicleModelDTO, QueryParams>().ReverseMap();
        }
    }
}
