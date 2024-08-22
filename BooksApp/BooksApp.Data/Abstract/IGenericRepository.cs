using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApp.Entity.Concrete;

namespace BooksApp.Data.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity:class
    {
        Task<TEntity> CreateAsync(TEntity entity);      // (C)reate
        Task<List<TEntity>> GetAllAsync();              // (R)ead
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> UpdateAsync(TEntity entity);      // (U)pdate
        Task DeleteAsync(TEntity entity);         // (D)elete
    }

}