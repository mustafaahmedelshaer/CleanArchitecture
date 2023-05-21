using CleanArchitecture.Application.Common.SharedResources;
using CleanArchitecture.Application.Communications;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.IRepositories;
using Microsoft.Extensions.Localization;
using Microsoft.EntityFrameworkCore;


namespace CleanArchitecture.Application.Services
{
    public class BookService
    {
        private readonly IStringLocalizer<GeneralMessages> _localization;
        private readonly IBookRepository _bookRepository;
        public BookService(IStringLocalizer<GeneralMessages> localization, IBookRepository bookRepository)
        {
            _localization = localization;
            _bookRepository = bookRepository;
        }

        public async Task<GeneralResponse<List<Book>>> GetAllAsync()
        {
            var results = await _bookRepository.GetAllAsync();
            return new GeneralResponse<List<Book>>(results);
        }
        public async Task<GeneralResponse<List<Book>>> GetAll()
        {
            var results = await _bookRepository.All().Where(b=>b.EmployeeId == 1)
                //.Select(d => d.Email)
                .ToListAsync();
            return new GeneralResponse<List<Book>>(results);
        }

        public async Task<GeneralResponse<Book>> GetByIdAsync(int Id)
        {
            var results = await _bookRepository.GetByIdAsync(Id);
            return new GeneralResponse<Book>(results);
        }


    }
}
