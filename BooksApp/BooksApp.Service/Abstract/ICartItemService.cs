using System;
using BooksApp.Shared.Dtos;
using BooksApp.Shared.ResponseDtos;

namespace BooksApp.Service.Abstract;

public interface ICartItemService
{
    Task<Response<NoContent>> AddToCartAsync(AddToCartDto addToCartDto);
    Task<Response<NoContent>> DeleteItemAsync(int cartItemId);
    Task<Response<NoContent>> ClearCartAsync(string userId);
    Task<Response<NoContent>> ChangeQuantityAsync(int cartItemId, int quantity);
}
