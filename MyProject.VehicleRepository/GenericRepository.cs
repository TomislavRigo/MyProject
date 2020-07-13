using Microsoft.EntityFrameworkCore;
using MyProject.DAL;
using MyProject.DTO.Common;
using MyProject.VehicleRepository.Common;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyProject.VehicleRepository
{
    public abstract class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : class
    {
        private readonly VehicleDbContext dbContext;

        public GenericRepository(VehicleDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<TModel> GetAllModelsAsync(Expression<Func<TModel, bool>> match, Expression<Func<TModel, string>> orderByExpression, IPaging paging, string sortType)
        {
            var vehicles = sortType == "asc" ?
                dbContext.Set<TModel>().AsNoTracking().Where(match).OrderBy(orderByExpression).Skip(paging.Skip).Take(paging.PageSize) :
                dbContext.Set<TModel>().AsNoTracking().Where(match).OrderByDescending(orderByExpression).Skip(paging.Skip).Take(paging.PageSize);
            paging.TotalItemsCount = dbContext.Set<TModel>().Where(match).AsNoTracking().Count();
            return vehicles;
        }

        public async Task<TModel> GetAsync(Guid id)
        {
            return await dbContext.Set<TModel>().FindAsync(id);
        }

        public async Task<int> AddAsync(TModel entity)
        {
            dbContext.Set<TModel>().Add(entity);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(TModel entity)
        {
            dbContext.Set<TModel>().Update(entity);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            dbContext.Set<TModel>().Remove(dbContext.Find<TModel>(id));
            return await dbContext.SaveChangesAsync();
        }
    }
}