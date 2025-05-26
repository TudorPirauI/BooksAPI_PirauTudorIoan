using Tema1.Core.DTOs;

namespace Tema1.Api.Services
{
    public interface IAuthorService
    {
        Task<List<AuthorDto>> GetAllAuthorsAsync();

        Task<IEnumerable<AuthorDto>> GetFilteredAsync(string? name, int? minBooks, int pageNumber, int pageSize, string? sortBy);

        Task UpdateAuthorAsync(int id, UpdateAuthorDto dto);
    }
}
