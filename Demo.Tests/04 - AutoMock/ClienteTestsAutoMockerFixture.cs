using Demo.Clientes;
using Moq.AutoMock;

namespace Demo.Tests.AutoMock
{
    [CollectionDefinition(nameof(ClienteAutoMockerCollection))]
    public class ClienteAutoMockerCollection : ICollectionFixture<ClienteTestsAutoMockerFixture>
    { }

    public class ClienteTestsAutoMockerFixture : IDisposable
    {
        public ClienteService ClienteService;
        public AutoMocker Mocker;

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

        public ClienteService ObterClienteService()
        {
            Mocker = new AutoMocker();
            return Mocker.CreateInstance<ClienteService>();
        }

        public void Dispose()
        {
        }
    }
}
