using System;
using System.Threading.Tasks;
using MyProject.DTO.Common;

namespace MyProject.VehicleRepository.Common
{
    public interface IVehicleMakeRepository
    {
        Task<IVehicleMakeModel> GetVehicleMakesAsync(Guid id);
        Task<IVehicleMakeModel> GetAllMakesAsync(IFilter filter, IPaging paging); 
        Task<int> AddVehicleMakeAsync(IVehicleMakeModel vehicleMake);
        Task<int> DeleteVehicleMakeAsync(IVehicleMakeModel vehicleMake);
        Task<int> UpdateVehicleMakeAsync(IVehicleMakeModel vehicleMake);
    }
}