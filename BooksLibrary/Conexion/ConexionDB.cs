using BooksLibrary.Models;
using MongoDB.Driver;

namespace BooksLibrary.Conexion
{
    public class ConexionDB
    {
        public MongoClient Client;
        public IMongoDatabase Database;
        public IMongoCollection<Cliente> Clientes;
        public IMongoCollection<Libros> Libros;
        public ConexionDB()
        {
            Client = new MongoClient("mongodb://127.0.0.1:27017");
            Database = Client.GetDatabase("ClientresSotreDb");
            Libros = Database.GetCollection<Libros>("Libros");
            Clientes = Database.GetCollection<Cliente>("Clientes");

        }


    }
}
