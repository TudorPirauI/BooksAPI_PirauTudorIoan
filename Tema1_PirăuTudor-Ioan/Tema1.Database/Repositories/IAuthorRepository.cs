using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tema1.Core.Entities;

namespace Tema1.Database.Repositories
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllWithBooksAsync();
    }
}

