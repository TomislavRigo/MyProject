using AutoMapper;
using MyProject.DAL;
using MyProject.DTO;
using MyProject.DTO.Common;
using MyProject.VehicleRepository.Common;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.VehicleRepository
{
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        private readonly IGenericRepository genericRepository;
        private readonly IMapper mapper;

        public VehicleMakeRepository(IGenericRepository genericRepository, IMapper mapper)
        {
            this.genericRepository = genericRepository;
            this.mapper = mapper;
        }

        public async Task<IVehicleMakeModel> GetAllMakesAsync(Filter filter)
        {
            var result = await genericRepository.GetAllModelsAsync<VehicleMake>();
            if (!string.IsNullOrEmpty(filter.Search))
            {
                result = result.Where(v => filter.SearchBy == "Name" ?
                v.Name.StartsWith(filter.Search, StringComparison.InvariantCultureIgnoreCase):
                v.Abrv.StartsWith(filter.Search, StringComparison.InvariantCultureIgnoreCase));

            }
            if (filter.SortType == "asc")
            {
                result = filter.SortBy == "Name" ? result.OrderBy(v => v.Name) : result.OrderBy(v => v.Abrv);             
            }
            else
            {
                result = filter.SortBy == "Abrv" ? result.OrderByDescending(v => v.Name) : result.OrderByDescending(v => v.Abrv);
            }
            //var vehicleMakeList = new VehicleMakeModel();
            //vehicleMakeList.VehicleMakes = result;
            var vehicleMakeList = new VehicleMakeModel()
            {
                //VehicleMakes = result.Skip((pageNumber - 1) * pageSize).Take(pageSize)
                VehicleMakes = result
            };
            return vehicleMakeList;
        }

        public async Task<IVehicleMakeModel> GetVehicleMakesAsync(Guid id)
        {
            var result = await genericRepository.GetAsync<VehicleMake>(id);
            return mapper.Map<IVehicleMakeModel>(result);
        }

        public async Task<int> AddVehicleMakeAsync(IVehicleMakeModel vehicleMake)
        {
            var vehicle = mapper.Map<VehicleMake>(vehicleMake);
            return await genericRepository.AddAsync(vehicle);
        }

        public async Task<int> UpdateVehicleMakeAsync(IVehicleMakeModel vehicleMake)
        {
            var vehicle = mapper.Map<VehicleMake>(vehicleMake);
            return await genericRepository.UpdateAsync(vehicle);
        }

        public async Task<int> DeleteVehicleMakeAsync(IVehicleMakeModel vehicleMake)
        {
            var vehicle = mapper.Map<VehicleMake>(vehicleMake);
            return await genericRepository.DeleteAsync(vehicle);
        }
    }
}
