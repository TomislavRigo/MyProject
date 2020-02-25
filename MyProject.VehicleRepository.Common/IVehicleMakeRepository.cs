using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyProject.DTO.Common;

namespace MyProject.VehicleRepository.Common
{
    public interface IVehicleMakeRepository
    {
        Task<IVehicleMakeDTO> GetVehicleMakesAsync(Guid id);
        Task<IEnumerable<IVehicleMakeDTO>> GetAllMakesAsync(IFilter filter, IPaging paging);
        Task<int> AddVehicleMakeAsync(IVehicleMakeDTO vehicleMake);
        Task<int> DeleteVehicleMakeAsync(IVehicleMakeDTO vehicleMake);
        Task<int> UpdateVehicleMakeAsync(IVehicleMakeDTO vehicleMake);
    }
}