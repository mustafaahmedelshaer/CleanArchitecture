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
        public async Task<IEnumerable<Book>> GetEmployeeByLastName(string lastname)
        {
            return await _employeeContext.Books
                .Where(m => m.LastName == lastname)
                .ToListAsync();
        }
    }
}
