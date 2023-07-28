using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BooksLibrary.Models
{
    public class Libros
    {

        [BsonId]
        public ObjectId _id { get; set; }

        public string Nombre { get; set; }
        public int Edad { get; set; }

        public string Email { get; set; }
        public string direccion { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public int Libro_id { get; set; }


    }
}
