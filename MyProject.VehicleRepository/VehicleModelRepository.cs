using MyProject.DAL;
using MyProject.VehicleMakeRepository;
using MyProject.VehicleRepository.Common;
using System.Threading.Tasks;

namespace MyProject.VehicleRepository
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        private readonly IGenericRepository genericRepository;

        public VehicleModelRepository(IGenericRepository genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task<VehicleModel> GetVehicleModelAsync(int id)
        {
            return await genericRepository.GetAsync<VehicleModel>(id);
        }

        public async Task<int> AddVehicleModelAsync(VehicleModel vehicleModel)
        {
            return await genericRepository.AddAsync<VehicleModel>(vehicleModel);
        }

        public async Task<int> UpdateVehicleModelAsync(VehicleModel vehicleModel)
        {
            return await genericRepository.UpdateAsync<VehicleModel>(vehicleModel);
        }

        public async Task<int> DeleteVehicleModelAsync(VehicleModel vehicleModel)
        {
            return await genericRepository.DeleteAsync<VehicleModel>(vehicleModel);
        }
    }
}
