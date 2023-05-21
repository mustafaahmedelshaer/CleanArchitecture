using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.IRepositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.IRepositories
{
    public interface IBookRepository : IRepository<Book>
    {
        //custom operations here
        Task<IEnumerable<Book>> GetEmployeeByLastName(string lastname);
    }
}
