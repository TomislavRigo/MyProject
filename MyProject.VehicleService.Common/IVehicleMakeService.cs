using MyProject.DAL;
using MyProject.DTO;
using MyProject.DTO.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProject.VehicleService.Common
{
    public interface IVehicleMakeService
    {
        Task<IVehicleMakeDTO> GetVehicleMakeAsync(Guid id);
        Task<IDictionary<string, object>> GetAllMakesAsync(IFilter filter, IPaging paging);
        Task<int> AddVehicleMakeAsync(IVehicleMakeDTO vehicleMake);
        Task<int> UpdateVehicleMakeAsync(IVehicleMakeDTO vehicleMake);
        Task<int> DeleteVehicleMakeAsync(IVehicleMakeDTO vehicleMake);
    }
}
