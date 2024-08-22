using System;

namespace BooksApp.Entity.Concrete;

public class Cart
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string UserId { get; set; }
    public List<CartItem> CartItems { get; set; }
}
