using MyProject.DAL;
using MyProject.DTO;
using MyProject.DTO.Common;
using System;
using System.Threading.Tasks;

namespace MyProject.VehicleService.Common
{
    public interface IVehicleModelService
    {
        Task<IVehicleModelModel> GetAllModelsAsync(string searchBy, string search, string sortBy, string sortType, int page, int pageSize);
        Task<IVehicleModelModel> GetVehicleModelAsync(Guid id);
        Task<int> AddVehicleModelAsync(IVehicleModelModel vehicleModel);
        Task<int> UpdateVehicleModelAsync(IVehicleModelModel vehicleModel);
        Task<int> DeleteVehicleModelAsync(IVehicleModelModel vehicleModel);
    }
}
