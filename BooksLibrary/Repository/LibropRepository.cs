using BooksLibrary.Conexion;
using BooksLibrary.Interfaces;
using BooksLibrary.Models;
using MongoDB.Driver;

namespace BooksLibrary.Repository
{
    public class LibropRepository : LibrosInterface
    {
        private readonly IMongoCollection<Libros> _libros;
        private readonly IMongoCollection<Cliente> _cliente;

        public LibropRepository()
        {
            var conexion = new ConexionDB();
            _libros = conexion.Database.GetCollection<Libros>("Libros");
        }

        public bool Delete(Libros libros)
        {
            var filter = Builders<Libros>.Filter.Where(l => l._id == libros._id);
            _libros.DeleteOne(filter);
            return true;

        }

        public ICollection<Cliente> GeLibroByCliente(int id)
        {
            var filter = Builders<Cliente>.Filter.Where(c => id == c.libro_id);
            var result = _cliente.Find(filter).ToList();
            return result;

        }

     

        public Libros GetLibro(int id)
        {
            var filter = Builders<Libros>.Filter.Where(l => l._id == id);
            var result = _libros.Find(filter).FirstOrDefault();
            return result;
        }

        public ICollection<Libros> GetLibros()
        {

            var libros = _libros.Find(_ => true).ToList();
            return libros;
        }

        public bool LibrosExits(int id)
        {
            var filter = Builders<Libros>.Filter.Where(l => l._id == id);
            return true;
        }

        public bool Save(Libros libro)
        {
            _libros.InsertOne(libro);
            return true;
        }

        public bool update(Libros libros)
        {
            var filter = Builders<Libros>.Filter
                .Where(l => l._id == libros._id);
            _libros.ReplaceOne(filter, libros);
            return true;

        }
    }
}
