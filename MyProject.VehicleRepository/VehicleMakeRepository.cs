using MyProject.DAL;
using MyProject.VehicleMakeRepository;
using MyProject.VehicleRepository.Common;
using System.Threading.Tasks;

namespace MyProject.VehicleRepository
{
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        private readonly IGenericRepository genericRepository;

        public VehicleMakeRepository(IGenericRepository genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task<VehicleMake> GetVehicleMakesAsync(int id)
        {
            return await genericRepository.GetAsync<VehicleMake>(id);
        }

        public async Task<int> AddVehicleMakeAsync(VehicleMake vehicleMake)
        {
            return await genericRepository.AddAsync(vehicleMake);
        }

        public async Task<int> UpdateVehicleMakeAsync(VehicleMake vehicleMake)
        {
            return await genericRepository.UpdateAsync(vehicleMake);
        }

        public async Task<int> DeleteVehicleMakeAsync(VehicleMake vehicleMake)
        {
            return await genericRepository.DeleteAsync(vehicleMake);
        }
    }
}
