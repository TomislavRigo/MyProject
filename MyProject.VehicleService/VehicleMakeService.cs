using MyProject.DAL;
using MyProject.VehicleRepository.Common;
using MyProject.VehicleService.Common;
using System.Threading.Tasks;

namespace MyProject.VehicleService
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly IVehicleMakeRepository vehicleMakeRepository;

        public VehicleMakeService(IVehicleMakeRepository vehicleMakeRepository)
        {
            this.vehicleMakeRepository = vehicleMakeRepository;
        }

        public async Task<VehicleMake> GetVehicleMakeAsync(int id)
        {
            return await vehicleMakeRepository.GetVehicleMakesAsync(id);
        }

        public async Task<int> AddVehicleMakeAsync(VehicleMake vehicleMake)
        {
            return await vehicleMakeRepository.AddVehicleMakeAsync(vehicleMake);
        }

        public async Task<int> UpdateVehicleMakeAsync(VehicleMake vehicleMake)
        {
            return await vehicleMakeRepository.UpdateVehicleMakeAsync(vehicleMake);
        }

        public async Task<int> DeleteVehicleMakeAsync(VehicleMake vehicleMake)
        {
            return await vehicleMakeRepository.DeleteVehicleMakeAsync(vehicleMake);
        }
    }
}
