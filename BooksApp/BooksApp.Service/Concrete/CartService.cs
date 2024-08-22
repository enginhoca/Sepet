using System;
using AutoMapper;
using BooksApp.Data.Abstract;
using BooksApp.Entity.Concrete;
using BooksApp.Service.Abstract;
using BooksApp.Shared.Dtos;
using BooksApp.Shared.ResponseDtos;

namespace BooksApp.Service.Concrete;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;

    public CartService(ICartRepository cartRepository, IMapper mapper)
    {
        _cartRepository = cartRepository;
        _mapper = mapper;
    }

    public async Task<Response<CartDto>> GetCartByUserId(string userId)
    {
        var cart = await _cartRepository.GetCartByUserIdAsync(userId);
        if (cart == null)
        {
            return Response<CartDto>.Fail("İlgili kullanıcıya ait bir sepet bulunamadı!", 404);
        }
        var cartDto = _mapper.Map<CartDto>(cart);
        return Response<CartDto>.Success(cartDto, 200);
    }

    public async Task<Response<NoContent>> InitializeCartAsync(string userId)
    {
        var cart = new Cart { UserId = userId };
        await _cartRepository.CreateAsync(cart);
        return Response<NoContent>.Success(201);
    }
}
