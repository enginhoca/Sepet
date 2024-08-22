using System;
using BooksApp.Entity.Concrete;

namespace BooksApp.Data.Abstract;

public interface ICartRepository : IGenericRepository<Cart>
{
    Task<Cart> GetCartByUserIdAsync(string userId);
}
