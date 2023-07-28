using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BooksLibrary.Models
{
    public class Cliente
    {
        [BsonId]
        public int _id { get; set; }      
        public string nombre { get; set; }
        public int edad { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public string ciudad { get; set; }
        public string pais { get; set; }
        public int libro_id { get; set; }




    }
}
