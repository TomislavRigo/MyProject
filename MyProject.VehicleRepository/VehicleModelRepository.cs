using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyProject.DAL;
using MyProject.DTO;
using MyProject.DTO.Common;
using MyProject.VehicleRepository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public Task<IEnumerable<IVehicleModelDTO>> GetAllModelsAsync(IFilter filter, IPaging paging, ISorting sorting)
        {
            var result = genericRepository.GetAllModelsAsync<VehicleModel>(CreateFilterExpression(filter.Search, filter.SearchBy), CreateOrderByExpression(sorting.SortBy), paging.PageSize, paging.Skip, sorting.SortType);
            paging.TotalItemsCount = result.Item2;
            return Task.FromResult(mapper.Map<IEnumerable<IVehicleModelDTO>>(result.Item1));
        }
        public async Task<IVehicleModelDTO> GetVehicleModelAsync(Guid id)
        {
            return mapper.Map<IVehicleModelDTO>(await genericRepository.GetAsync<VehicleModel>(id));
        }

        public Task<int> AddVehicleModelAsync(IVehicleModelDTO vehicleModel)
        {
            var model = mapper.Map<VehicleModel>(vehicleModel);
            return genericRepository.AddAsync(model);
        }

        public Task<int> UpdateVehicleModelAsync(IVehicleModelDTO vehicleModel)
        {
            var model = mapper.Map<VehicleModel>(vehicleModel);
            return genericRepository.UpdateAsync(model);
        }

        public Task<int> DeleteVehicleModelAsync(IVehicleModelDTO vehicleModel)
        {
            var model = mapper.Map<VehicleModel>(vehicleModel);
            return genericRepository.DeleteAsync(model);
        }

        private static Expression<Func<VehicleModel, bool>> CreateFilterExpression(string search, string searchBy)
        {
            if (!string.IsNullOrEmpty(search))
            {
                return v => searchBy == "Name" ?
                v.Name.StartsWith(search, StringComparison.InvariantCultureIgnoreCase) :
                v.Abrv.StartsWith(search, StringComparison.InvariantCultureIgnoreCase);
            }
            return x => x.Name.StartsWith(String.Empty);
        }

        private static Expression<Func<VehicleModel, string>> CreateOrderByExpression(string sortBy)
        {
            if (sortBy == "Name" || sortBy == null)
            {
                return v => v.Name;
            }
            else
            {
                return v => v.Abrv;
            }
        }
    }
}