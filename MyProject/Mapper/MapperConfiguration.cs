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
            CreateMap<VehicleMake, IVehicleMakeModel>().ReverseMap();
            CreateMap<VehicleModel, IVehicleModelModel>().ReverseMap();
            CreateMap<VehicleMakeModel, VehicleMake>().ReverseMap();
            CreateMap<VehicleModelModel, VehicleModel>().ReverseMap();
            #endregion
            #region Data Transfer Objects
            CreateMap<VehicleMakeModel, IVehicleMakeModel>().ReverseMap();
            CreateMap<VehicleModelModel, IVehicleModelModel>().ReverseMap();
            CreateMap<Filter, IFilter>().ReverseMap();
            CreateMap<Paging, IPaging>().ReverseMap();
            #endregion
            #region Data View Objects
            CreateMap<IVehicleMakeModel, VehicleMakeViewModel>().ReverseMap();
            CreateMap<IVehicleModelModel, VehicleModelViewModel>().ReverseMap();
            #endregion
            CreateMap<VehicleMake, VehicleMakeViewModel>().ReverseMap();

        }
    }
}
