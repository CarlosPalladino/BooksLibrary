using BooksLibrary.Models;

namespace BooksLibrary.Interfaces
{
    public interface LibrosInterface
    {

        ICollection<Libros> GetLibros();

        Libros GetLibro(int id);
        
        ICollection<Cliente> GeLibroByCliente(int id);

        bool LibrosExits(int id);

        bool Save(Libros libro);
        bool update(Libros libros);
        bool Delete(Libros libros);

    }
}
