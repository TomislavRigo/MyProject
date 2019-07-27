using System.Threading.Tasks;
using MyProject.DAL;

namespace MyProject.VehicleRepository.Common
{
    public interface IVehicleMakeRepository
    {
        Task<VehicleMake> GetVehicleMakesAsync(int id);
        Task<int> AddVehicleMakeAsync(VehicleMake vehicleMake);
        Task<int> DeleteVehicleMakeAsync(VehicleMake vehicleMake);
        Task<int> UpdateVehicleMakeAsync(VehicleMake vehicleMake);
    }
}