using MyProject.DAL;
using MyProject.DTO;
using MyProject.DTO.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProject.VehicleService.Common
{
    public interface IVehicleModelService
    {
        Task<IDictionary<string, object>> GetAllModelsAsync(string searchBy, string search, string sortBy, string sortType, int page, int pageSize);
        Task<IVehicleModelDTO> GetVehicleModelAsync(Guid id);
        Task<int> AddVehicleModelAsync(IVehicleModelDTO vehicleModel);
        Task<int> UpdateVehicleModelAsync(IVehicleModelDTO vehicleModel);
        Task<int> DeleteVehicleModelAsync(IVehicleModelDTO vehicleModel);
    }
}
