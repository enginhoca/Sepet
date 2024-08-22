using System;
using BooksApp.Shared.Dtos;
using BooksApp.Shared.ResponseDtos;

namespace BooksApp.Service.Abstract;

public interface ICartService
{
    Task<Response<NoContent>> InitializeCartAsync(string userId);
    Task<Response<CartDto>> GetCartByUserId(string userId);
}
