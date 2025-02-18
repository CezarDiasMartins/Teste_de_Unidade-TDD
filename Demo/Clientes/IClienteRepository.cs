using System.Collections.Generic;

namespace Demo.Clientes
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> GetAll();
        Cliente GetById(int id);
        void Add(Cliente cliente);
    }
}