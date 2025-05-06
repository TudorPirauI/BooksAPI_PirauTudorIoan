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
    }
}

