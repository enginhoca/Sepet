using System;
using BooksApp.Data.Abstract;
using BooksApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BooksApp.Data.Concrete.EfCore.Repositories;

public class EfCoreCartRepository : EfCoreGenericRepository<Cart>, ICartRepository
{
    public EfCoreCartRepository(BooksAppDbContext booksAppDbContext) : base(booksAppDbContext)
    {
    }
    private BooksAppDbContext Context
    {
        get { return _dbContext as BooksAppDbContext; }
    }

    public async Task<Cart> GetCartByUserIdAsync(string userId)
    {
        return await Context
            .Carts
            .Where(x => x.UserId == userId)
            .Include(x => x.CartItems)
            .ThenInclude(y => y.Book)
            .FirstOrDefaultAsync();
    }
}
