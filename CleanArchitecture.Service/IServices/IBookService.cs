using CleanArchitecture.Application.Communications;
using CleanArchitecture.Application.DTOS.BooksDto;
using CleanArchitecture.Domain.Entities;


namespace CleanArchitecture.Application.IServices
{
    public interface IBookService
    {

        Task<GeneralResponse<List<Book>>> GetAllAsync();

        Task<GeneralResponse<List<BookDto>>> GetAll();
        Task<GeneralResponse<Book>> GetByIdAsync(Guid Id);
        Task<GeneralResponse<Book>> Add(BookInput Input);
        Task<GeneralResponse<Book>> Update(BookUpdateInput Input);

        Task<GeneralResponse<bool>> SoftDelete(Guid Id);

    }
}
