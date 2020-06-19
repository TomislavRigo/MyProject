using AutoMapper;
using MyProject.DAL;
using MyProject.DTO;
using MyProject.DTO.Common;
using MyProject.MVC.Models;

namespace MyProject.MVC.Mapper
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            #region Database Objects
            CreateMap<VehicleMake, IVehicleMakeDTO>().ReverseMap();
            CreateMap<VehicleModel, IVehicleModelDTO>().ReverseMap();
            #endregion
            #region Data Transfer Objects
            #endregion
            #region Data View Objects
            CreateMap<IVehicleMakeDTO, VehicleMakeViewModel>().ReverseMap();
            CreateMap<IVehicleModelDTO, VehicleModelViewModel>().ReverseMap();
            #endregion

        }
    }
}
