using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BooksLibrary.Models
{
    public class Libros
    {

        [BsonId]
        public int _id { get; set; }

        public string titulo { get; set; }
        public string autor { get; set; }
       public int anio_publicacion { get; set; }
        public string genero { get; set; }
        public string editorial { get; set; }
        public string sinopsis { get; set; }
        public int precio { get; set; }


    }
}
