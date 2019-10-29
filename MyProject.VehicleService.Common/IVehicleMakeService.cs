using MyProject.DAL;
using MyProject.DTO.Common;
using System;
using System.Threading.Tasks;

namespace MyProject.VehicleService.Common
{
    public interface IVehicleMakeService
    {
        Task<IVehicleMakeModel> GetVehicleMakeAsync(Guid id);
        Task<IVehicleMakeModel> GetAllMakesAsync();
        Task<int> AddVehicleMakeAsync(IVehicleMakeModel vehicleMake);
        Task<int> UpdateVehicleMakeAsync(IVehicleMakeModel vehicleMake);
        Task<int> DeleteVehicleMakeAsync(IVehicleMakeModel vehicleMake);
    }
}
