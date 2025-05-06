using Tema1.Core.DTOs;

namespace Tema1.Api.Services
{
    public interface IAuthorService
    {
        Task<List<AuthorDto>> GetAllAuthorsAsync();
    }
}
