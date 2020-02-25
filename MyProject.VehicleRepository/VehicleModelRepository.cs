using AutoMapper;
using MyProject.DAL;
using MyProject.DTO;
using MyProject.DTO.Common;
using MyProject.VehicleRepository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.VehicleRepository
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        private readonly IGenericRepository genericRepository;
        private readonly IMapper mapper;

        public VehicleModelRepository(IGenericRepository genericRepository, IMapper mapper)
        {
            this.genericRepository = genericRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<IVehicleModelDTO>> GetAllModelsAsync(IFilter filter, IPaging paging)
        {
            var result = await genericRepository.GetAllModelsAsync<VehicleModel>();

            if (!string.IsNullOrEmpty(filter.Search))
            {
                result = result.Where(v => filter.SearchBy == "Name" ?
                v.Name.StartsWith(filter.Search, StringComparison.InvariantCultureIgnoreCase) :
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
         
            return mapper.Map<IEnumerable<IVehicleModelDTO>>(result.Skip(paging.Skip).Take(paging.PageSize));
        }
        public async Task<IVehicleModelDTO> GetVehicleModelAsync(Guid id)
        {
            return mapper.Map<IVehicleModelDTO>(await genericRepository.GetAsync<VehicleModel>(id));
        }

        public async Task<int> AddVehicleModelAsync(IVehicleModelDTO vehicleModel)
        {
            var model = mapper.Map<VehicleModel>(vehicleModel);
            return await genericRepository.AddAsync(model);
        }

        public async Task<int> UpdateVehicleModelAsync(IVehicleModelDTO vehicleModel)
        {
            var model = mapper.Map<VehicleModel>(vehicleModel);
            return await genericRepository.UpdateAsync(model);
        }

        public async Task<int> DeleteVehicleModelAsync(IVehicleModelDTO vehicleModel)
        {
            var model = mapper.Map<VehicleModel>(vehicleModel);
            return await genericRepository.DeleteAsync(model);
        }
    }
}
