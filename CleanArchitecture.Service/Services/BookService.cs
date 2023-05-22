using CleanArchitecture.Application.Common.SharedResources;
using CleanArchitecture.Application.Communications;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.IRepositories;
using Microsoft.Extensions.Localization;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Application.DTOS.BooksDto;
using CleanArchitecture.Application.IServices;

namespace CleanArchitecture.Application.Services
{
    public class BookService: IBookService
    {
        //private readonly IStringLocalizer<GeneralMessages> _localization;
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<GeneralResponse<List<Book>>> GetAllAsync()
        {
            var results = await _bookRepository.GetAllAsync();
            return new GeneralResponse<List<Book>>(results);
        }
        public async Task<GeneralResponse<List<BookDto>>> GetAll()
        {
            var results = await _bookRepository.All().Where(b=>b.Id == new Guid()  )
                 .Select(x => new BookDto
                 {
                   
                 })
                .ToListAsync();
            return new GeneralResponse<List<BookDto>>(results, results.Count().ToString() );
            //

        }

        public async Task<GeneralResponse<Book>> GetByIdAsync(Guid Id)
        {
            var results = await _bookRepository.GetByIdAsync(Id);
            return new GeneralResponse<Book>(results);
        }
        public async Task<GeneralResponse<Book>> Add(BookInput Input)
        {
            //Mapping to Entity 
           var Book =  new Book()
            {
                Email = "Email",
                FirstName = "FirstName",
                LastName = "LastName",
                PhoneNumber = "PhoneNumber",
            };

            var results = await _bookRepository.AddAsync(Book);
            return new GeneralResponse<Book>(results, " _localization[\"AddedSuccessfully\"]");
        }
        public async Task<GeneralResponse<Book>> Update(BookUpdateInput Input)
        {
            //Mapping to Entity 
            var results = await _bookRepository.UpdateAsync(new Book());
            return new GeneralResponse<Book>(results, " _localization[\"UpdatedSuccessfully\"]");
        }
        public async Task<GeneralResponse<bool>> SoftDelete(Guid Id)
        {
            //Mapping to Entity 
            var results = await _bookRepository.SoftDelete(Id);

            return new GeneralResponse<bool>(results, " _localization[\"DeletedSuccessfully\"]");
        }
    }
}
