using MyProject.DAL;
using MyProject.VehicleRepository.Common;
using MyProject.VehicleService.Common;
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

        public async Task<VehicleModel> GetVehicleModelAsync(int id)
        {
            return await vehicleModelRepository.GetVehicleModelAsync(id);
        }

        public async Task<int> AddVehicleModelAsync(VehicleModel vehicleModel)
        {
            return await vehicleModelRepository.AddVehicleModelAsync(vehicleModel);
        }

        public async Task<int> UpdateVehicleModelAsync(VehicleModel vehicleModel)
        {
            return await vehicleModelRepository.UpdateVehicleModelAsync(vehicleModel);
        }

        public async Task<int> DeleteVehicleModelAsync(VehicleModel vehicleModel)
        {
            return await vehicleModelRepository.DeleteVehicleModelAsync(vehicleModel);
        }
    }
}
