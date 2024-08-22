using System;
using System.Text.Json.Serialization;

namespace BooksApp.Shared.Dtos;

public class OrderItemDto
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    [JsonIgnore]
    public OrderDto Order { get; set; }
    public int BookId { get; set; }
    [JsonIgnore]
    public BookDto Book { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
