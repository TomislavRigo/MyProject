using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.VehicleRepository.Common
{
    public interface IGenericRepository
    {
        Task<T> GetAsync<T>(Guid id) where T : class;
        Task<IEnumerable<T>> GetAllModelsAsync<T>() where T : class;
        Task<int> AddAsync<T>(T entity) where T : class;
        Task<int> UpdateAsync<T>(T entity) where T : class;
        Task<int> DeleteAsync<T>(T entity) where T : class;
    }
}