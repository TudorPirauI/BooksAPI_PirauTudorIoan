using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tema1.Core.Entities;

namespace Tema1.Database.Repositories
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllWithBooksAsync();

        Task<List<Author>> GetFilteredAsync(
            string? name,
            int? minBooks,
            int pageNumber,
            int pageSize,
            string? sortBy
        );
        Task SaveChangesAsync();

    }


}
