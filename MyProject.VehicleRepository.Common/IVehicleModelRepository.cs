using System;
using System.Threading.Tasks;
using MyProject.DAL;
using MyProject.DTO.Common;

namespace MyProject.VehicleRepository.Common
{
    public interface IVehicleModelRepository
    {
        Task<IVehicleModelModel> GetAllModelsAsync();
        Task<IVehicleModelModel> GetVehicleModelAsync(Guid id);
        Task<int> AddVehicleModelAsync(IVehicleModelModel vehicleModel);
        Task<int> UpdateVehicleModelAsync(IVehicleModelModel vehicleModel);
        Task<int> DeleteVehicleModelAsync(IVehicleModelModel vehicleModel);
    }
}