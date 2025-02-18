using Demo.Clientes;

namespace Demo.Tests.Fixtures
{
    public class ClienteTestsFixture : IDisposable
    {
        [CollectionDefinition(nameof(ClienteCollection))]
        public class ClienteCollection : ICollectionFixture<ClienteTestsFixture> { }
        
        public IEnumerable<Cliente> GerarClientes(int quantidade, bool valido)
        {
            var clientes = new List<Cliente>();

            for (int i = 0; i < quantidade; i++)
                clientes.Add(new Cliente($"Cliente{i}", valido));

            return clientes;
        }

        public IEnumerable<Cliente> ObterClientesVariados()
        {
            var clientes = new List<Cliente>();

            clientes.AddRange(GerarClientes(50, true).ToList());
            clientes.AddRange(GerarClientes(50, false).ToList());

            return clientes;
        }

        public Cliente GerarClienteValido()
        {
            return GerarClientes(1, true).FirstOrDefault();
        }

        public Cliente GerarClienteInvalido()
        {
            return GerarClientes(1, false).FirstOrDefault();
        }

        public void Dispose() { }
    }
}