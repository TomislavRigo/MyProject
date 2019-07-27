using MyProject.DAL;
using System.Threading.Tasks;

namespace MyProject.VehicleService.Common
{
    public interface IVehicleMakeService
    {
        Task<VehicleMake> GetVehicleMakeAsync(int id);
        Task<int> AddVehicleMakeAsync(VehicleMake vehicleMake);
        Task<int> UpdateVehicleMakeAsync(VehicleMake vehicleMake);
        Task<int> DeleteVehicleMakeAsync(VehicleMake vehicleMake);
    }
}
