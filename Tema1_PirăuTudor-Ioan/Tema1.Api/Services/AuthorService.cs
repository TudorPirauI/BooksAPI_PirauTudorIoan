using Tema1.Core.DTOs;
using Tema1.Database.Repositories;

namespace Tema1.Api.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;

        public AuthorService(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<AuthorDto>> GetAllAuthorsAsync()
        {
            var authors = await _repository.GetAllWithBooksAsync();

            return authors.Select(a => new AuthorDto
            {
                Id = a.Id,
                Name = a.Name,
                Books = a.Books.Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title
                }).ToList()
            }).ToList();
        }

        public async Task<IEnumerable<AuthorDto>> GetFilteredAsync(string? name, int? minBooks, int pageNumber, int pageSize, string? sortBy)
        {
            var authors = await _repository.GetFilteredAsync(name, minBooks, pageNumber, pageSize, sortBy);

            return authors.Select(a => new AuthorDto
            {
                Id = a.Id,
                Name = a.Name,
                Books = a.Books.Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title
                }).ToList()
            });
        }

        public async Task UpdateAuthorAsync(int id, UpdateAuthorDto dto)
        {
            var authors = await _repository.GetAllWithBooksAsync();
            var author = authors.FirstOrDefault(a => a.Id == id);

            if (author == null)
                throw new KeyNotFoundException("Author not found.");

            author.Name = dto.Name;

            // Nu ai metodă de Update separată în repo, deci salvăm direct în context:
            await _repository.SaveChangesAsync();
        }

    }
}
