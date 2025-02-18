using System.Collections.Generic;
using System.Linq;

namespace Demo.Clientes
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _clienteRepository.GetAll();
        }
        
        public IEnumerable<Cliente> GetAllValidos()
        {
            return _clienteRepository.GetAll().Where(c => c.Valido);
        }

        public Cliente GetById(int id)
        {
            return _clienteRepository.GetById(id);
        }

        public void Add(Cliente cliente)
        {
            if (cliente.Valido) _clienteRepository.Add(cliente);
            else cliente.Errors.Add("Erro ao inserir!");
        }
    }
}