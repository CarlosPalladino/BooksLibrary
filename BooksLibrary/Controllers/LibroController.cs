using BooksLibrary.Interfaces;
using BooksLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace BooksLibrary.Controllers
{

    [Route("api/libros")]
    [ApiController]
    public class LibroController : Controller
    {
        private readonly LibrosInterface _libs;
        private readonly ClienteInterface _cliente;

        public LibroController(LibrosInterface libros)
        {
            _libs = libros;
        }
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetLibros()
        {


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cliente = _libs.GetLibros();

            return Ok(cliente);

        }
        [HttpGet("{libroId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetLibro(int libroId)
        {
            if (!_libs.LibrosExits(libroId))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var libro = _libs.GetLibro(libroId);
            return Ok(libro);
        }

        [HttpGet("libros/{clienteId}")]
        [ProducesResponseType(200)]
        public IActionResult GetLibrosByCliente(int libro_Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!_cliente.clienteExists(libro_Id))
                return BadRequest(ModelState);

            var libro = _libs.GeLibroByCliente(libro_Id);

            return Ok(libro);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult CreateLibro([FromBody] Libros Createlibros)
        {
            if(CreateLibro == null)
                return BadRequest(ModelState);
          var cliente  = _libs.GetLibros().Where(l=>l.sinopsis.Trim().ToUpper() == Createlibros.sinopsis.ToUpper()).FirstOrDefault();
            if (cliente != null)
            {

                ModelState.AddModelError("","El Libro ya existe");
                return StatusCode(422, ModelState);

            }
            return Ok("Libro creado");

        }



        [HttpPut("{LibroId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult UpdateLibro(int id, [FromBody] Libros libro)
        {
            if (!_libs.LibrosExits(id))
                return BadRequest(ModelState);
            if (!ModelState.IsValid)
                return BadRequest();
            var LibroUpdate = _libs.update(libro);
            return Ok(LibroUpdate);

        }
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(200)]
        public IActionResult DeleteLibro(int libroId)
        {

            if (!_libs.LibrosExits(libroId))
                return NotFound();

            var LibroToDelete = _libs.GetLibro(libroId);
            if (!_libs.Delete(LibroToDelete))
            {

                ModelState.AddModelError("", "Algo paso mientras se intentaba eliminar");
            }
            return Ok("Eliminado Exitoso");


        }
    }
}
