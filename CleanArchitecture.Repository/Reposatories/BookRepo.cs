using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.IRepositories;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.InfraStructure.Reposatories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.InfraStructure.Reposatories
{
    public class BookRepo : Repository<Book>, IBookRepository
    {
        public BookRepo(DBDemoContext DbtContext) : base(DbtContext)
        {

        }
        public async Task<bool> SoftDelete(Guid Id)
        {
            var Input = await _context.Books.FirstOrDefaultAsync(b=>b.Id == Id);
            if (Input != null)
            {
                Input.IsDeleted = true;
                _context.Books.Update(Input);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;

            }

        }
    }
}
