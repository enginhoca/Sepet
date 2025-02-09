using System;

namespace BooksApp.Shared.Dtos;

public class OrderDto
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public string UserId { get; set; }
    public List<OrderItemDto> OrderItems { get; set; }
}
