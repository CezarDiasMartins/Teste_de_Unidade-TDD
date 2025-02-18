using Demo.Clientes;
using Demo.Tests.Fixtures;
using Moq;
using static Demo.Tests.Fixtures.ClienteTestsFixture;

namespace Demo.Tests.Mock
{
    [Collection(nameof(ClienteCollection))]
    public class ClienteServiceTests
    {
        private readonly ClienteTestsFixture _clienteTestsfixture;
        public ClienteServiceTests(ClienteTestsFixture clienteTestsfixture)
        {
            _clienteTestsfixture = clienteTestsfixture;
        }

        [Fact(DisplayName = "Adicionar cliente com sucesso")]
        [Trait("Categoria", "Cliente Service Mock Tests")]
        public void ClienteService_Adicionar_DeveExecutarComSucesso()
        {
            // Arrange
            var cliente = _clienteTestsfixture.GerarClienteValido();
            var clienteRepository = new Mock<IClienteRepository>();
            var clienteService = new ClienteService(clienteRepository.Object);

            // Act
            clienteService.Add(cliente);

            // Assert
            clienteRepository.Verify(r => r.Add(cliente), Times.Once);
        }

        [Fact(DisplayName = "Adicionar cliente com falha")]
        [Trait("Categoria", "Cliente Service Mock Tests")]
        public void ClienteService_Adicionar_DeveFalharDevidoClienteInvalido()
        {
            // Arrange
            var cliente = _clienteTestsfixture.GerarClienteInvalido();
            var clienteRepository = new Mock<IClienteRepository>();
            var clienteService = new ClienteService(clienteRepository.Object);

            // Act
            clienteService.Add(cliente);

            // Assert
            clienteRepository.Verify(r => r.Add(cliente), Times.Never);
        }

        [Fact(DisplayName = "Obter clientes ativos")]
        [Trait("Categoria", "Cliente Service Mock Tests")]
        public void ClienteService_ObterTodosAtivos_DeveRetornarApenasClientesValidos()
        {
            // Arrange
            var clienteRepository = new Mock<IClienteRepository>();

            clienteRepository.Setup(c => c.GetAll()) // Quando o método GetAll() for chamado
                .Returns(_clienteTestsfixture.ObterClientesVariados()); // Irá retornar ObterClientesVariados()

            var clienteService = new ClienteService(clienteRepository.Object);

            // Act
            var clientes = clienteService.GetAllValidos();

            // Assert
            Assert.True(clientes.Any());
            Assert.False(clientes.Count(c => !c.Valido) > 0);
        }
    }
}