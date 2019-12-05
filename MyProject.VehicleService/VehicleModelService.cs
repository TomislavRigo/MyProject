using MyProject.DAL;
using MyProject.DTO.Common;
using MyProject.VehicleRepository.Common;
using MyProject.VehicleService.Common;
using System;
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

        public async Task<IVehicleModelModel> GetAllModelsAsync(string searchBy, string search)
        {
            return await vehicleModelRepository.GetAllModelsAsync(searchBy, search);
        }
        public async Task<IVehicleModelModel> GetVehicleModelAsync(Guid id)
        {
            return await vehicleModelRepository.GetVehicleModelAsync(id);
        }

        public async Task<int> AddVehicleModelAsync(IVehicleModelModel vehicleModel)
        {
            return await vehicleModelRepository.AddVehicleModelAsync(vehicleModel);
        }

        public async Task<int> UpdateVehicleModelAsync(IVehicleModelModel vehicleModel)
        {
            return await vehicleModelRepository.UpdateVehicleModelAsync(vehicleModel);
        }

        public async Task<int> DeleteVehicleModelAsync(IVehicleModelModel vehicleModel)
        {
            return await vehicleModelRepository.DeleteVehicleModelAsync(vehicleModel);
        }
    }
}
