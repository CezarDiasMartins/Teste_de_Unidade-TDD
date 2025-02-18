using Demo.Clientes;
using Demo.Tests.Fixtures;
using Moq;
using Moq.AutoMock;
using Xunit.Abstractions;
using static Demo.Tests.Fixtures.ClienteTestsFixture;

namespace Demo.Tests.AutoMock
{
    [Collection(nameof(ClienteCollection))]
    public class ClienteServiceAutoMockerTests
    {
        private readonly ClienteTestsFixture _clienteTestsfixture;
        readonly ITestOutputHelper _outputHelper;
        public ClienteServiceAutoMockerTests(ClienteTestsFixture clienteTestsfixture, ITestOutputHelper outputHelper)
        {
            _clienteTestsfixture = clienteTestsfixture;
            _outputHelper = outputHelper;
        }

        [Fact(DisplayName = "Adicionar cliente com sucesso")]
        [Trait("Categoria", "Cliente Service AutoMock Tests")]
        public void ClienteService_Adicionar_DeveExecutarComSucesso()
        {
            // Arrange
            var cliente = _clienteTestsfixture.GerarClienteValido();
            var mocker = new AutoMocker();
            var clienteService = mocker.CreateInstance<ClienteService>();

            // Act
            clienteService.Add(cliente);

            // Assert
            mocker.GetMock<IClienteRepository>().Verify(r => r.Add(cliente), Times.Once);
        }

        [Fact(DisplayName = "Adicionar cliente com falha")]
        [Trait("Categoria", "Cliente Service AutoMock Tests")]
        public void ClienteService_Adicionar_DeveFalharDevidoClienteInvalido()
        {
            // Arrange
            var cliente = _clienteTestsfixture.GerarClienteInvalido();
            var mocker = new AutoMocker();
            var clienteService = mocker.CreateInstance<ClienteService>();

            // Act
            clienteService.Add(cliente);

            // Assert
            mocker.GetMock<IClienteRepository>().Verify(r => r.Add(cliente), Times.Never);
        }

        [Fact(DisplayName = "Obter clientes ativos")]
        [Trait("Categoria", "Cliente Service AutoMock Tests")]
        public void ClienteService_ObterTodosAtivos_DeveRetornarApenasClientesValidos()
        {
            // Arrange
            var mocker = new AutoMocker();
            var clienteService = mocker.CreateInstance<ClienteService>();

            mocker.GetMock<IClienteRepository>().Setup(c => c.GetAll()) // Quando o método GetAll() for chamado
                .Returns(_clienteTestsfixture.ObterClientesVariados()); // Irá retornar ObterClientesVariados()

            // Act
            var clientes = clienteService.GetAllValidos();

            // Assert
            Assert.True(clientes.Any());
            Assert.False(clientes.Count(c => !c.Valido) > 0);

            _outputHelper.WriteLine("Todos os clientes válidos foram obtidos!");
        }
    }
}