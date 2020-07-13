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
using System.Threading.Tasks;

namespace MyProject.VehicleRepository
{
    public class VehicleMakeRepository : GenericRepository<VehicleMake>, IVehicleMakeRepository
    {
        private readonly IMapper mapper;

        public VehicleMakeRepository(IMapper mapper, VehicleDbContext dbContext) : base(dbContext)
        {
            this.mapper = mapper;
        }

        public Task<IEnumerable<IVehicleMakeDTO>> GetAllMakesAsync(IFilter filter, IPaging paging, ISorting sorting)
        {
            var result = base.GetAllModelsAsync(CreateFilterExpression(filter.Search, filter.SearchBy), CreateOrderByExpression(sorting.SortBy), paging, sorting.SortType);
            return Task.FromResult(mapper.Map<IEnumerable<IVehicleMakeDTO>>(result));
        }

        public async Task<IVehicleMakeDTO> GetVehicleMakesAsync(Guid id)
        {
            var result = await base.GetAsync(id);
            return mapper.Map<IVehicleMakeDTO>(result);
        }

        public Task<int> AddVehicleMakeAsync(IVehicleMakeDTO vehicleMake)
        {
            var vehicle = mapper.Map<VehicleMake>(vehicleMake);
            return base.AddAsync(vehicle);
        }

        public Task<int> UpdateVehicleMakeAsync(IVehicleMakeDTO vehicleMake)
        {
            var vehicle = mapper.Map<VehicleMake>(vehicleMake);
            return base.UpdateAsync(vehicle);
        }

        public Task<int> DeleteVehicleMakeAsync(Guid id)
        {
            return base.DeleteAsync(id);
        }
        private static Expression<Func<VehicleMake, bool>> CreateFilterExpression(string search, string searchBy)
        {
            if (!string.IsNullOrEmpty(search))
            {
                return v => searchBy == "Name" ?
                v.Name.StartsWith(search, StringComparison.InvariantCultureIgnoreCase) :
                v.Abrv.StartsWith(search, StringComparison.InvariantCultureIgnoreCase);
            }
            return x => x.Name.StartsWith(String.Empty);
        }

        private static Expression<Func<VehicleMake, string>> CreateOrderByExpression(string sortBy)
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