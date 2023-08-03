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
            var clienteSave = repo.Save(createCliente);
            if (!clienteSave)
            {
                ModelState.AddModelError("", "paso algo mientras se guardaba el usuario");

                return StatusCode(500, ModelState);
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

        if(!repo.clienteExists(clienteId))
                return BadRequest(ModelState);


            var updateClient = repo.Update(updateCliente);

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
