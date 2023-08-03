using BooksLibrary.Models;

namespace BooksLibrary.Interfaces
{
    public interface ClienteInterface
    {
        ICollection<Cliente> GetClientes();

        Cliente GetCliente(int ClienteId);

        bool clienteExists(int id);

        bool Save(Cliente cliente);
        bool Delete(Cliente cliente);
        bool createClient(Cliente cliente);
        bool Update(Cliente cliente);


    }
}
