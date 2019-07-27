using System.Threading.Tasks;
using MyProject.DAL;

namespace MyProject.VehicleRepository.Common
{
    public interface IVehicleModelRepository
    {
        Task<int> AddVehicleModelAsync(VehicleModel vehicleModel);
        Task<int> DeleteVehicleModelAsync(VehicleModel vehicleModel);
        Task<VehicleModel> GetVehicleModelAsync(int id);
        Task<int> UpdateVehicleModelAsync(VehicleModel vehicleModel);
    }
}