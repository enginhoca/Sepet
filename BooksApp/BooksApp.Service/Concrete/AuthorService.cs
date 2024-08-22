using AutoMapper;
using BooksApp.Data.Abstract;
using BooksApp.Service.Abstract;
using BooksApp.Shared.Dtos;
using BooksApp.Shared.ResponseDtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Service.Concrete
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository=authorRepository;
            _mapper=mapper;
        }

        public Task<Response<AuthorDto>> AddAsync(AuthorDto addAuthorDto)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoContent>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<List<AuthorDto>>> GetAllAsync()
        {
            var authors = await _authorRepository.GetAllAsync();
            if (authors==null)
            {
                return Response<List<AuthorDto>>.Fail("Bir sorun oluştu", StatusCodes.Status400BadRequest);
            }
            if (authors.Count==0)
            {
                return Response<List<AuthorDto>>.Success(StatusCodes.Status204NoContent);
            }
            var authorDtoList = _mapper.Map<List<AuthorDto>>(authors);
            return Response<List<AuthorDto>>.Success(authorDtoList, StatusCodes.Status200OK);
        }

        public Task<Response<AuthorDto>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<AuthorDto>> UpdateAsync(AuthorDto editAuthorDto)
        {
            throw new NotImplementedException();
        }
    }
}
