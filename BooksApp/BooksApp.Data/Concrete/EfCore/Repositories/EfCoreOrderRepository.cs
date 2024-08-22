using System;
using BooksApp.Data.Abstract;
using BooksApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BooksApp.Data.Concrete.EfCore.Repositories;

public class EfCoreOrderRepository : EfCoreGenericRepository<Order>, IOrderRepository
{
    public EfCoreOrderRepository(BooksAppDbContext booksAppDbContext) : base(booksAppDbContext)
    {
    }
    private BooksAppDbContext Context
    {
        get { return _dbContext as BooksAppDbContext; }
    }
    public async Task<List<Order>> GetAllOrdersAsync(string userId = null)
    {
        if (userId == null)
        {
            return await Context
                .Orders
                .Include(x => x.OrderItems)
                .ThenInclude(y => y.Book)
                .ToListAsync();
        }
        return await Context
                .Orders
                .Where(x => x.UserId == userId)
                .Include(x => x.OrderItems)
                .ThenInclude(y => y.Book)
                .ToListAsync();
    }

    public async Task<Order> GetOrderAsync(int orderId)
    {
        return await Context
                .Orders
                .Where(x => x.Id == orderId)
                .Include(x => x.OrderItems)
                .ThenInclude(y => y.Book)
                .FirstOrDefaultAsync();
    }
}
