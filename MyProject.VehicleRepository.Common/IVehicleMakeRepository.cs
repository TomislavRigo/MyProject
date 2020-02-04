using System;
using System.Threading.Tasks;
using MyProject.DAL;
using MyProject.DTO;
using MyProject.DTO.Common;

namespace MyProject.VehicleRepository.Common
{
    public interface IVehicleMakeRepository
    {
        Task<IVehicleMakeModel> GetVehicleMakesAsync(Guid id);
        Task<IVehicleMakeModel> GetAllMakesAsync(Filter filter); 
        Task<int> AddVehicleMakeAsync(IVehicleMakeModel vehicleMake);
        Task<int> DeleteVehicleMakeAsync(IVehicleMakeModel vehicleMake);
        Task<int> UpdateVehicleMakeAsync(IVehicleMakeModel vehicleMake);
    }
}