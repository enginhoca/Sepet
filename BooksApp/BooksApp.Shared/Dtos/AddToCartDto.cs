using System;

namespace BooksApp.Shared.Dtos;

public class AddToCartDto
{
    public string UserId { get; set; }
    public int BookId { get; set; }
    public int Quantity { get; set; }
}
