using Microsoft.AspNetCore.Mvc;
using Tema1.Api.Services;
using Tema1.Core.DTOs;

namespace Tema1.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            return Ok(authors);
        }

        [HttpGet("filtered")]
        public async Task<IActionResult> GetFiltered(
            [FromQuery] string? name,
            [FromQuery] int? minBooks,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? sortBy = null)
        {
            var authors = await _authorService.GetFilteredAsync(name, minBooks, pageNumber, pageSize, sortBy);
            return Ok(authors);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateAuthorDto dto)
        {
            await _authorService.UpdateAuthorAsync(id, dto);
            return NoContent(); 
        }

    }
}
