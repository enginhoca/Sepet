using BooksApp.Shared.Dtos;
using BooksApp.Shared.ResponseDtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Shared.Helpers.Abstract
{
    public interface IImageHelper
    {
        Task<Response<ImageDto>> Upload(IFormFile file,string directoryName);
    }
}
