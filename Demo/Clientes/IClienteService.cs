using System.Collections.Generic;

namespace Demo.Clientes
{
    public interface IClienteService
    {
        IEnumerable<Cliente> GetAll();
        Cliente GetById(int id);
        void Add(Cliente cliente);
    }
}