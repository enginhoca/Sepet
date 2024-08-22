using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApp.Data.Abstract;
using BooksApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BooksApp.Data.Concrete.EfCore.Repositories
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category>, ICategoryRepository
    {
        public EfCoreCategoryRepository(BooksAppDbContext booksAppDbContext):base(booksAppDbContext)
        {
            
        }
        private BooksAppDbContext Context{ get { return _dbContext as BooksAppDbContext; }}
        public async Task<List<Category>> GetActiveCategoriesAsync()
        {
            //LINQ to Sql ifadeler
            List<Category> categories = 
                await Context
                    .Categories
                    .Where(c=>c.IsActive)
                    .ToListAsync();
            return categories;
        }



        public async Task<List<Category>> GetHomeCategoriesAsync()
        {
            List<Category> categories =
                await Context
                    .Categories
                    .Where(c=>c.IsHome && c.IsActive)
                    .ToListAsync();
            return categories;
        }
    }
}