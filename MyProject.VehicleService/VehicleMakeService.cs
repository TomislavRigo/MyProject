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

        public async Task<IDictionary<string, object>> GetAllMakesAsync(string searchBy, string search, string sortBy, string sortType, int page, int pageSize) 
        {
            var paging = new Paging()
            {
                PageNumber = page,
                PageSize = pageSize
            };

            var filter = new Filter()
            {
                SearchBy = searchBy,
                Search = search,
                SortBy = sortBy,
                SortType = sortType

            };

            var makes = await vehicleMakeRepository.GetAllMakesAsync(filter, paging);

            var result = new Dictionary<string, object>()
            {
                {"makes", makes},
                {"paging", paging }
            };

            return result;
        }

        public Task<int> AddVehicleMakeAsync(IVehicleMakeDTO vehicleMake)
        {
            return vehicleMakeRepository.AddVehicleMakeAsync(vehicleMake);
        }

        public Task<int> UpdateVehicleMakeAsync(IVehicleMakeDTO vehicleMake)
        {
            return vehicleMakeRepository.UpdateVehicleMakeAsync(vehicleMake);
        }

        public Task<int> DeleteVehicleMakeAsync(IVehicleMakeDTO vehicleMake)
        {
            return vehicleMakeRepository.DeleteVehicleMakeAsync(vehicleMake);
        }
    }
}
