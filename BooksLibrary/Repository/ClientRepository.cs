using BooksLibrary.Interfaces;
using BooksLibrary.Models;
using BooksLibrary.Conexion;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

using MongoDB.Bson;

using System.Security.Cryptography;
using MongoDB.Bson;

namespace BooksLibrary.Repository
{
    public class ClientRepository : ClienteInterface
    {
        private readonly IMongoCollection<Cliente> _clientes;
        private readonly IMongoCollection<Libros> _libros;


        public ClientRepository()
        {
            var conexion = new ConexionDB();
            _clientes = conexion.Database.GetCollection<Cliente>("Clientes");

        }
        public bool clienteExists(int id)
        {
            //var objectId = new ObjectId(id.ToString());

            var filter = Builders<Cliente>.Filter.Where(c => c._id == id);
            var result = _clientes.CountDocuments(filter);

            return result > 0;
        }

        public bool createClient(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Cliente cliente)
        {

            var filter = Builders<Cliente>.Filter.Eq(c => c._id, cliente._id);
            _clientes.DeleteOne(filter);
            return true;
        }

        public Cliente GetCliente(int ClienteId)
        {
            //var objectId = new ObjectId(ClienteId.ToString());
            var filter = Builders<Cliente>.Filter.Where(c => c._id == ClienteId);
            var result = _clientes.Find(filter).FirstOrDefault();
            return result;
        }

        public ICollection<Cliente> GetClientes()
        {
            var clientes = _clientes.Find(_ => true).ToList();

            return clientes;

        }


        public bool Save(Cliente cliente)
        {

            _clientes.InsertOne(cliente);

            return true;
        }


        public bool Update(Cliente cliente)
        {
            var filter = Builders<Cliente>.Filter
                   .Where(c => c._id == cliente._id);
            _clientes.ReplaceOne(filter, cliente);

            return true;
        }

    }
}
