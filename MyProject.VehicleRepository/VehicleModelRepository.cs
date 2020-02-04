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

        public async Task<IVehicleModelModel> GetAllModelsAsync(Filter filter)
        {
            var result = await genericRepository.GetAllModelsAsync<VehicleModel>();
            if (!string.IsNullOrEmpty(filter.Search))
            {
                result = result.Where(v => filter.SearchBy == "Name" ?
                v.Name.StartsWith(filter.Search, StringComparison.InvariantCultureIgnoreCase) :
                v.Abrv.StartsWith(filter.Search, StringComparison.InvariantCultureIgnoreCase));
            }

            if (filter.SortType == "asc")
            {
                if (filter.SortBy == "Name")
                {
                    result = result.OrderBy(v => v.Name);
                }
                else 
                {
                    result = result.OrderBy(v => v.Abrv);
                }
            }
            else
            {
                if (filter.SortBy == "Name")
                {
                    result = result.OrderByDescending(v => v.Name);
                }
                else
                {
                    result = result.OrderByDescending(v => v.Abrv);
                }
            }

            var vehicleMakeList = new VehicleModelModel()
            {
                VehicleModels = result
            };
            return vehicleMakeList;
        }
        public async Task<IVehicleModelModel> GetVehicleModelAsync(Guid id)
        {
            return mapper.Map<IVehicleModelModel>(await genericRepository.GetAsync<VehicleModel>(id));
        }

        public async Task<int> AddVehicleModelAsync(IVehicleModelModel vehicleModel)
        {
            var model = mapper.Map<VehicleModel>(vehicleModel);
            return await genericRepository.AddAsync(model);
        }

        public async Task<int> UpdateVehicleModelAsync(IVehicleModelModel vehicleModel)
        {
            var model = mapper.Map<VehicleModel>(vehicleModel);
            return await genericRepository.UpdateAsync(model);
        }

        public async Task<int> DeleteVehicleModelAsync(IVehicleModelModel vehicleModel)
        {
            var model = mapper.Map<VehicleModel>(vehicleModel);
            return await genericRepository.DeleteAsync(model);
        }
    }
}
