using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyProject.DAL;
using MyProject.DTO.Common;

namespace MyProject.VehicleRepository.Common
{
    public interface IVehicleMakeRepository : IGenericRepository<VehicleMake>
    {
        Task<IVehicleMakeDTO> GetVehicleMakesAsync(Guid id);
        Task<IEnumerable<IVehicleMakeDTO>> GetAllMakesAsync(IFilter filter, IPaging paging, ISorting sorting);
        Task<int> AddVehicleMakeAsync(IVehicleMakeDTO vehicleMake);
        Task<int> UpdateVehicleMakeAsync(IVehicleMakeDTO vehicleMake);
        Task<int> DeleteVehicleMakeAsync(Guid id);
    }
}