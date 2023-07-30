using BooksLibrary.Models;

namespace BooksLibrary.Interfaces
{
    public interface ClienteInterface
    {
        ICollection<Cliente> GetClientes();

        Cliente GetCliente(int ClienteId);

        //ICollection<Libros> GetLibrosByCliente(int libro_id); // va en libro

        bool clienteExists(int id);

        bool Save(Cliente cliente);
        bool Delete(Cliente cliente);
        bool createClient(Cliente cliente);
        bool Update(Cliente cliente);


    }
}
