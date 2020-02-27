﻿using Microsoft.EntityFrameworkCore;
using MyProject.DAL;
using MyProject.VehicleRepository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<T>> GetAllModelsAsync<T>() where T : class
        {

            var result = await dbContext.Set<T>().ToListAsync();
            return result;
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
