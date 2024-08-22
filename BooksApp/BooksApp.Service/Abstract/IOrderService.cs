using System;
using BooksApp.Shared.Dtos;
using BooksApp.Shared.ResponseDtos;

namespace BooksApp.Service.Abstract;

public interface IOrderService
{
    Task<Response<int>> CreateAsync(OrderDto orderDto);
    Task<Response<OrderDto>> GetOrderAsync(int orderId);
    Task<Response<List<OrderDto>>> GetOrdersAsync(string? userId = null);
}
