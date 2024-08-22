using System;
using System.Text.Json.Serialization;

namespace BooksApp.Shared.Dtos;

public class CartItemDto
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public int BookId { get; set; }
    public BookDto Book { get; set; }
    public int CartId { get; set; }
    [JsonIgnore]
    public CartDto Cart { get; set; }
    public int Quantity { get; set; }
}
