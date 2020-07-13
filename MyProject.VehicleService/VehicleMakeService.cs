using MyProject.DAL;
using MyProject.DTO;
using MyProject.DTO.Common;
using MyProject.VehicleRepository.Common;
using MyProject.VehicleService.Common;
using System;
using System.Collections.Generic;
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

        public async Task<IVehicleMakeDTO> GetVehicleMakeAsync(Guid id)
        {
            return await vehicleMakeRepository.GetVehicleMakesAsync(id);
        }

        public async Task<IEnumerable<IVehicleMakeDTO>> GetAllMakesAsync(IFilter filter, IPaging paging, ISorting sorting) 
        {
            return await vehicleMakeRepository.GetAllMakesAsync(filter, paging, sorting);
        }

        public Task<int> AddVehicleMakeAsync(IVehicleMakeDTO vehicleMake)
        {
            return vehicleMakeRepository.AddVehicleMakeAsync(vehicleMake);
        }

        public Task<int> UpdateVehicleMakeAsync(IVehicleMakeDTO vehicleMake)
        {
            return vehicleMakeRepository.UpdateVehicleMakeAsync(vehicleMake);
        }

        public Task<int> DeleteVehicleMakeAsync(Guid id)
        {
            return vehicleMakeRepository.DeleteVehicleMakeAsync(id);
        }
    }
}