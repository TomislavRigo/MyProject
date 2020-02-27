using AutoMapper;
using MyProject.DAL;
using MyProject.DTO;
using MyProject.DTO.Common;
using MyProject.VehicleRepository.Common;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<IVehicleMakeDTO>> GetAllMakesAsync(IFilter filter, IPaging paging)
        {
            var result = await genericRepository.GetAllModelsAsync<VehicleMake>();

            if (!string.IsNullOrEmpty(filter.Search))
            {
                result = result.Where(v => filter.SearchBy == "Name" ?
                v.Name.StartsWith(filter.Search, StringComparison.InvariantCultureIgnoreCase):
                v.Abrv.StartsWith(filter.Search, StringComparison.InvariantCultureIgnoreCase));
            }

            paging.TotalItemsCount = result.Count();
            
            if (filter.SortType == "asc")
            {
                result = filter.SortBy == "Name" || filter.SortBy == null ? result.OrderBy(v => v.Name) : result.OrderBy(v => v.Abrv);             
            }
            else
            {
                result = filter.SortBy == "Name" || filter.SortBy == null ? result.OrderByDescending(v => v.Name) : result.OrderByDescending(v => v.Abrv);
            }

            return mapper.Map<IEnumerable<IVehicleMakeDTO>>(result.Skip(paging.Skip).Take(paging.PageSize));
        }

        public async Task<IVehicleMakeDTO> GetVehicleMakesAsync(Guid id)
        {
            var result = await genericRepository.GetAsync<VehicleMake>(id);
            return mapper.Map<IVehicleMakeDTO>(result);
        }

        public Task<int> AddVehicleMakeAsync(IVehicleMakeDTO vehicleMake)
        {
            var vehicle = mapper.Map<VehicleMake>(vehicleMake);
            return genericRepository.AddAsync(vehicle);
        }

        public Task<int> UpdateVehicleMakeAsync(IVehicleMakeDTO vehicleMake)
        {
            var vehicle = mapper.Map<VehicleMake>(vehicleMake);
            return genericRepository.UpdateAsync(vehicle);
        }

        public Task<int> DeleteVehicleMakeAsync(IVehicleMakeDTO vehicleMake)
        {
            var vehicle = mapper.Map<VehicleMake>(vehicleMake);
            return genericRepository.DeleteAsync(vehicle);
        }
    }
}
