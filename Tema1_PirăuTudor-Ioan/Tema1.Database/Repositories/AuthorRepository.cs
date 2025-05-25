using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tema1.Core.Entities;

namespace Tema1.Database.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _context;

        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Author>> GetAllWithBooksAsync()
        {
            return await _context.Authors.Include(a => a.Books).ToListAsync();
        }

        public async Task<List<Author>> GetFilteredAsync(string? name, int? minBooks, int pageNumber, int pageSize, string? sortBy)
        {
            var query = _context.Authors.Include(a => a.Books).AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(a => a.Name.Contains(name));

            if (minBooks.HasValue)
                query = query.Where(a => a.Books.Count >= minBooks.Value);

            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                if (sortBy.Equals("name", StringComparison.OrdinalIgnoreCase))
                    query = query.OrderBy(a => a.Name);
                else if (sortBy.Equals("bookCount", StringComparison.OrdinalIgnoreCase))
                    query = query.OrderByDescending(a => a.Books.Count);
            }

            query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return await query.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
