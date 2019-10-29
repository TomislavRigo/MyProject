using MyProject.DAL;
using MyProject.DTO.Common;
using MyProject.VehicleRepository.Common;
using MyProject.VehicleService.Common;
using System;
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

        public async Task<IVehicleMakeModel> GetVehicleMakeAsync(Guid id)
        {
            return await vehicleMakeRepository.GetVehicleMakesAsync(id);
        }

        public async Task<IVehicleMakeModel> GetAllMakesAsync() 
        {
            var result = await vehicleMakeRepository.GetAllMakesAsync();
            return result;
        }

        public async Task<int> AddVehicleMakeAsync(IVehicleMakeModel vehicleMake)
        {
            return await vehicleMakeRepository.AddVehicleMakeAsync(vehicleMake);
        }

        public async Task<int> UpdateVehicleMakeAsync(IVehicleMakeModel vehicleMake)
        {
            return await vehicleMakeRepository.UpdateVehicleMakeAsync(vehicleMake);
        }

        public async Task<int> DeleteVehicleMakeAsync(IVehicleMakeModel vehicleMake)
        {
            return await vehicleMakeRepository.DeleteVehicleMakeAsync(vehicleMake);
        }
    }
}
