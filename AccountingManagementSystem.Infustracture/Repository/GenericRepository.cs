using AccountingManagementSystem.Domain.Common.Exceptions;
using AccountingManagementSystem.Domain.Interfaces;
using AccountingManagementSystem.Infustracture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingManagementSystem.Infustracture.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        private readonly IUnitofWork _unitofWork;
        public GenericRepository(AppDbContext context, IUnitofWork unitofWork) 
        { 
            _context = context;
            _unitofWork = unitofWork;
        }

        public async Task<T> AddAsync(T entity)
        {
            var result = await _context.AddAsync(entity);

            if(result.State == EntityState.Added)
            {
                await _unitofWork.SaveChangesAsync();
                return result.Entity;
            }

            throw new ModelNullException(nameof(entity), "Model is null");
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);

            var result = _context.Remove(entity);
            
            if(result.State == EntityState.Deleted)
            {
                await _unitofWork.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await _context.Set<T>().ToListAsync();

            if(result.Count > 0)
            {
                return result;
            }
            return Enumerable.Empty<T>();   
        }


        public async Task<T> GetByIdAsync(int id)
        {
            var result = await _context.Set<T>().FindAsync(id);
            if(result is not null)
            {
                return result;
            }

            throw new IdNullException("Id is null");
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var result = _context.Update(entity);

            if(result.State == EntityState.Modified)
            {
                await _unitofWork.SaveChangesAsync();
                return result.Entity;
            }

            throw new ModelNullException(nameof(entity), "Model is null");
        }
    }
}
