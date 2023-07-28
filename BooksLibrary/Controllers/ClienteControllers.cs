using BooksLibrary.Interfaces;
using BooksLibrary.Models;
using BooksLibrary.Repository;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace BooksLibrary.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClienteControllers : Controller
    {

        private readonly ClienteInterface repo;
        public ClienteControllers(ClienteInterface cliente)
        {
            repo = cliente;
        }
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetClientes()
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cliente = repo.GetClientes();


            return Ok(cliente);

        }
        [HttpGet("{clienteId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetCliente(int clienteId)
        {


            if (!repo.clienteExists(clienteId))
                return NotFound();

            var client = repo.GetCliente(clienteId);

            return Ok(client);
        }
        [HttpGet("libros/{clienteId}")]
        [ProducesResponseType(200)]
        public IActionResult GetLibrosByCliente(int libro_Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!repo.clienteExists(libro_Id)) ;


            var libro = repo.GetLibrosByCliente(libro_Id);

            return Ok(libro_Id);


        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCliente([FromBody] Cliente createCliente)
        {
            if (createCliente == null)
                return BadRequest(ModelState);
            var client = repo.GetClientes().Where(c => c.nombre.Trim().ToUpper() == createCliente.nombre.TrimEnd().ToUpper())
                .FirstOrDefault();
            if (client != null)
            {
                ModelState.AddModelError("", "ya esxiste este cliente");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok("success");
        }
        [HttpPut("{clientId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult UpdateClient(int clienteId, [FromBody] Cliente updateCliente)
        {
            if (UpdateClient == null)
                return BadRequest(ModelState);

            ObjectId clienteObjectId = new ObjectId(clienteId.ToString());

            if (!clienteObjectId.Equals(updateCliente._id))
                return BadRequest(ModelState);

            return Ok("Update Success");


        }
        [HttpDelete("{clienteId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(200)]
        public IActionResult DeleteClient(int clienteId)
        {


            if (!repo.clienteExists(clienteId))
                return NotFound();

            var deleteCliente = repo.GetCliente(clienteId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!repo.Delete(deleteCliente))
                ModelState.AddModelError("", "algo paso mientras se eliminaba");
            return Ok("delete success");

        }
    }
}
