using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BooksApp.Entity.Concrete;
using BooksApp.Shared.Dtos;

namespace BooksApp.Service.Mapping
{
    public class GeneralMappingProfile : Profile
    {
        public GeneralMappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, AddCategoryDto>().ReverseMap();
            CreateMap<Category, EditCategoryDto>().ReverseMap();

            CreateMap<Author, AuthorDto>().ReverseMap();

            CreateMap<Book, BookDto>()
                .ForMember(
                    bdto => bdto.Categories,
                    options => options.MapFrom(b => b.BookCategories.Select(bc => bc.Category))
                )
                .ReverseMap();

            CreateMap<Book, AddBookDto>().ReverseMap();
            CreateMap<Book, EditBookDto>().ReverseMap();

            CreateMap<Cart, CartDto>().ReverseMap();
            CreateMap<CartItem, CartItemDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();

        }
    }
}
