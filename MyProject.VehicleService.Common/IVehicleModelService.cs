using MyProject.DAL;
using System.Threading.Tasks;

namespace MyProject.VehicleService.Common
{
    public interface IVehicleModelService
    {
        Task<VehicleModel> GetVehicleModelAsync(int id);
        Task<int> AddVehicleModelAsync(VehicleModel vehicleModel);
        Task<int> UpdateVehicleModelAsync(VehicleModel vehicleModel);
        Task<int> DeleteVehicleModelAsync(VehicleModel vehicleModel);
    }
}
