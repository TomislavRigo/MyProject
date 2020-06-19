using MyProject.DTO.Common;
using MyProject.VehicleRepository.Common;
using MyProject.VehicleService.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProject.VehicleService
{
    public class VehicleModelService : IVehicleModelService
    {
        private readonly IVehicleModelRepository vehicleModelRepository;

        public VehicleModelService(IVehicleModelRepository vehicleModelRepository)
        {
            this.vehicleModelRepository = vehicleModelRepository;
        }

        public async Task<IDictionary<string, object>> GetAllModelsAsync(IFilter filter, IPaging paging)
        { 
            var models = await vehicleModelRepository.GetAllModelsAsync(filter, paging);

            var result = new Dictionary<string, object>()
            {
                {"models", models },
                {"paging", paging }
            };

            return result;
        }
        public async Task<IVehicleModelDTO> GetVehicleModelAsync(Guid id)
        {
            return await vehicleModelRepository.GetVehicleModelAsync(id);
        }

        public Task<int> AddVehicleModelAsync(IVehicleModelDTO vehicleModel)
        {
            return vehicleModelRepository.AddVehicleModelAsync(vehicleModel);
        }

        public Task<int> UpdateVehicleModelAsync(IVehicleModelDTO vehicleModel)
        {
            return vehicleModelRepository.UpdateVehicleModelAsync(vehicleModel);
        }

        public Task<int> DeleteVehicleModelAsync(IVehicleModelDTO vehicleModel)
        {
            return vehicleModelRepository.DeleteVehicleModelAsync(vehicleModel);
        }
    }
}