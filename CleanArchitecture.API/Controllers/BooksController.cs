using CleanArchitecture.Application.Communications;
using CleanArchitecture.Application.DTOS.BooksDto;
using CleanArchitecture.Application.IServices;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {


        private readonly IBookService _Book;

        public BooksController(IBookService book)
        {
            _Book = book;
        }

        [HttpGet("GetAll")]
        public async Task<GeneralResponse<List<BookDto>>> GetAll()
        {
            //bool isEnglish = Request.Headers["Accept-Language"].ToString().ToLower().Contains("en");
            return await _Book.GetAll();
        }

        [HttpGet("GetAllASync")]
        public async Task<GeneralResponse<List<Book>>> GetAllAsync()
        {
            //bool isEnglish = Request.Headers["Accept-Language"].ToString().ToLower().Contains("en");
            return await _Book.GetAllAsync();
        }
        [HttpPost("Add")]
        public async Task<GeneralResponse<Book>> Add()
        {
            //bool isEnglish = Request.Headers["Accept-Language"].ToString().ToLower().Contains("en");
            return await _Book.Add(new BookInput());
        }
        [HttpPut("Delete")]
        public async Task<GeneralResponse<bool>> Delete(Guid Id)
        {
            //bool isEnglish = Request.Headers["Accept-Language"].ToString().ToLower().Contains("en");
            return await _Book.SoftDelete(Id);
        }
    }
}
