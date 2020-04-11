using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyProject.VehicleRepository.Common
{
    public interface IGenericRepository
    {
        Task<T> GetAsync<T>(Guid id) where T : class;
        (IQueryable<T>, int) GetAllModelsAsync<T>(Expression<Func<T, bool>> match, Expression<Func<T, string>> orderByExpression, int take, int skip, string sortType) where T : class;
        Task<int> AddAsync<T>(T entity) where T : class;
        Task<int> UpdateAsync<T>(T entity) where T : class;
        Task<int> DeleteAsync<T>(T entity) where T : class;
    }
}