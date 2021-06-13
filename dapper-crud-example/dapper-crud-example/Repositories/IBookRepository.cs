using dapper_crud_example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dapper_crud_example.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
    }
}
