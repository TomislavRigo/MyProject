using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyProject.DAL;
using MyProject.DTO;
using MyProject.DTO.Common;

namespace MyProject.VehicleRepository.Common
{
    public interface IVehicleModelRepository : IGenericRepository<VehicleModel>
    {
        Task<IEnumerable<IVehicleModelDTO>> GetAllModelsAsync(IFilter filter, IPaging paging, ISorting sorting);
        Task<IVehicleModelDTO> GetVehicleModelAsync(Guid id);
        Task<int> AddVehicleModelAsync(IVehicleModelDTO vehicleModel);
        Task<int> UpdateVehicleModelAsync(IVehicleModelDTO vehicleModel);
        Task<int> DeleteVehicleModelAsync(Guid id);
    }
}