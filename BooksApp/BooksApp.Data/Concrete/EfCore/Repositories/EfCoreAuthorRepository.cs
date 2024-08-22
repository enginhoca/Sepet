using BooksApp.Data.Abstract;
using BooksApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Data.Concrete.EfCore.Repositories
{
    public class EfCoreAuthorRepository:EfCoreGenericRepository<Author>,IAuthorRepository
    {
        public EfCoreAuthorRepository(BooksAppDbContext booksAppDbContext):base(booksAppDbContext)
        {
            
        }
        private BooksAppDbContext Context
        {
            get { return _dbContext as BooksAppDbContext; }
        }


    }
}
