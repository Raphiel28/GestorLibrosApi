using GerstorLibrosAPI.Entidades;
using GerstorLibrosAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerstorLibrosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {

        private readonly AutorService _autorService;

        public AutorController(AutorService autorService)
        {
            _autorService = autorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Autor>>> ObtenerAutores()
        {
            var books = await _autorService.ObtenerTodosAutores();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Autor>> ObtenerAutor(int id)
        {
            var book = await _autorService.ObtenerAutorId(id);
            return book != null ? Ok(book) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Autor>> AgregarAutor([FromBody] Autor autor)
        {
            var createdBook = await _autorService.AgregarAutor(autor);
            return createdBook != null ? CreatedAtAction(nameof(ObtenerAutor), new { id = createdBook.Id }, createdBook) : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Autor>> ActualizarAutor(int id, [FromBody] Autor autor)
        {
            var updatedBook = await _autorService.ActualizarAutor(id, autor);
            return updatedBook != null ? Ok(updatedBook) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarAutor(int id)
        {
            return await _autorService.BorrarAutor(id) ? NoContent() : NotFound();
        }
    }
}
