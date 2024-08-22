using System;
using BooksApp.Entity.Concrete;

namespace BooksApp.Data.Abstract;

public interface IOrderRepository : IGenericRepository<Order>
{
    Task<List<Order>> GetAllOrdersAsync(string userId = null);
    Task<Order> GetOrderAsync(int orderId);
}
