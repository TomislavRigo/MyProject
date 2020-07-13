using MyProject.DTO.Common;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyProject.VehicleRepository.Common
{
    public interface IGenericRepository<TModel> where TModel : class
    {
        Task<TModel> GetAsync(Guid id);
        IQueryable<TModel> GetAllModelsAsync(Expression<Func<TModel, bool>> match, Expression<Func<TModel, string>> orderByExpression, IPaging paging, string sortType);
        Task<int> AddAsync(TModel entity);
        Task<int> UpdateAsync(TModel entity);
        Task<int> DeleteAsync(Guid id);
    }
}