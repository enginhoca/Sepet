using System;

namespace BooksApp.Shared.Dtos;

public class CartDto
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string UserId { get; set; }
    public List<CartItemDto> CartItems { get; set; }
}
