using System;
using BooksApp.Data.Abstract;
using BooksApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BooksApp.Data.Concrete.EfCore.Repositories;

public class EfCoreCartItemRepository : EfCoreGenericRepository<CartItem>, ICartItemRepository
{
    public EfCoreCartItemRepository(BooksAppDbContext booksAppDbContext) : base(booksAppDbContext)
    {
    }
    private BooksAppDbContext Context
    {
        get { return _dbContext as BooksAppDbContext; }
    }
}
