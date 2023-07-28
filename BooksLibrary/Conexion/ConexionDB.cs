using BooksLibrary.Models;
using MongoDB.Driver;

namespace BooksLibrary.Conexion
{
    public class ConexionDB
    {
        public MongoClient Client;
        public IMongoDatabase Database;
      public IMongoCollection<Cliente> Clientes;
        public ConexionDB()
        {
            Client = new MongoClient("mongodb://127.0.0.1:27017");
            Database = Client.GetDatabase("ClientresSotreDb");
            Clientes =  Database.GetCollection<Cliente>("Clientes");
        }


    }
}
