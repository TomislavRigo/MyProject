using Microsoft.EntityFrameworkCore;
using MyProject.DAL;
using MyProject.VehicleRepository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.VehicleRepository
{
    public class GenericRepository : IGenericRepository
    {
        private readonly VehicleDbContext dbContext;

        public GenericRepository(VehicleDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public (IQueryable<T>, int) GetAllModelsAsync<T>(Expression<Func<T, bool>> match, Expression<Func<T, string>> orderByExpression, int take, int skip, string sortType) where T : class
        {
            var vehicles = sortType == "asc" ?
                dbContext.Set<T>().Where(match).OrderBy(orderByExpression).Skip(skip).Take(take).AsNoTracking() :
                dbContext.Set<T>().Where(match).OrderByDescending(orderByExpression).Skip(skip).Take(take).AsNoTracking();
            var vehiclesCount = dbContext.Set<T>().Where(match).Count();
            return (vehicles, vehiclesCount);
        }

        public async Task<T> GetAsync<T>(Guid id) where T : class
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public Task<int> AddAsync<T>(T entity) where T : class
        {
            dbContext.Set<T>().Add(entity);
            return dbContext.SaveChangesAsync();
        }

        public Task<int> UpdateAsync<T>(T entity) where T : class
        {
            dbContext.Set<T>().Update(entity);
            return dbContext.SaveChangesAsync();
        }

        public Task<int> DeleteAsync<T>(T entity) where T : class
        {
            dbContext.Set<T>().Remove(entity);
            return dbContext.SaveChangesAsync();
        }
    }
}
