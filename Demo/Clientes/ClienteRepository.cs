using System.Collections.Generic;

namespace Demo.Clientes
{
    public class ClienteRepository : IClienteRepository
    {
        List<Cliente> clientes = new List<Cliente>()
        {
            new Cliente(1, "a", true),
            new Cliente(2, "b", true),
            new Cliente(3, "c", true),
            new Cliente(4, "d", false),
            new Cliente(4, "e", false)
        };

        public IEnumerable<Cliente> GetAll()
        {
            //return _clienteRepository.GetAll();
            return clientes;
        }
        
        public Cliente GetById(int id)
        {
            // return _clienteRepository.GetById(id);
            foreach (var cliente in clientes)
                if(cliente.Id == id) return cliente;
            return null;
        }

        public void Add(Cliente cliente)
        {
            // _clienteRepository.Add(cliente);
            clientes.Add(cliente);
        }
    }
}