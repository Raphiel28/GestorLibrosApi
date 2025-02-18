using GerstorLibrosAPI.Entidades;
using GerstorLibrosAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerstorLibrosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly LibroService _libroService;

        public LibrosController(LibroService libroService)
        {
            _libroService = libroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Lilbros>>> ObtenerLibros()
        {
            var books = await _libroService.ObtenerTodosLibros();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Lilbros>> ObtenerLibro(int id)
        {
            var book = await _libroService.ObtenerLibroId(id);
            return book != null ? Ok(book) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Lilbros>> AgregarLibro([FromBody] Lilbros libro)
        {
            var createdBook = await _libroService.AgregarLibro(libro);
            return createdBook != null ? CreatedAtAction(nameof(ObtenerLibro), new { id = createdBook.Id }, createdBook) : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Lilbros>> ActualizarLibro(int id, [FromBody] Lilbros libro)
        {
            var updatedBook = await _libroService.ActualizarLibro(id, libro);
            return updatedBook != null ? Ok(updatedBook) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarLibro(int id)
        {
            return await _libroService.BorrarLibro(id) ? NoContent() : NotFound();
        }
    }
}
