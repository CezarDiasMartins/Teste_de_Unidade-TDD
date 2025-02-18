using Demo.Clientes;
using Moq;
using Xunit.Abstractions;

namespace Demo.Tests.AutoMock
{
    [Collection(nameof(ClienteAutoMockerCollection))]
    public class ClienteServiceAutoMockerFixtureTests
    {
        readonly ClienteTestsAutoMockerFixture _clienteTestsAutoMockerFixture;
        private readonly ClienteService _clienteService;
        readonly ITestOutputHelper _outputHelper;

        public ClienteServiceAutoMockerFixtureTests(ClienteTestsAutoMockerFixture clienteTestsAutoMockerFixture,
            ITestOutputHelper outputHelper)
        {
            _clienteTestsAutoMockerFixture = clienteTestsAutoMockerFixture;
            _clienteService = _clienteTestsAutoMockerFixture.ObterClienteService();
            _outputHelper = outputHelper;
        }

        [Fact(DisplayName = "Adicionar Cliente com Sucesso")]
        [Trait("Categoria", "Cliente Service AutoMockFixture Tests")]
        public void ClienteService_Adicionar_DeveExecutarComSucesso()
        {
            // Arrange
            var cliente = _clienteTestsAutoMockerFixture.GerarClienteValido();

            // Act
            _clienteService.Add(cliente);

            // Assert
            _clienteTestsAutoMockerFixture.Mocker.GetMock<IClienteRepository>()
                .Verify(r => r.Add(cliente), Times.Once);
        }

        [Fact(DisplayName = "Adicionar Cliente com Falha")]
        [Trait("Categoria", "Cliente Service AutoMockFixture Tests")]
        public void ClienteService_Adicionar_DeveFalharDevidoClienteInvalido()
        {
            // Arrange
            var cliente = _clienteTestsAutoMockerFixture.GerarClienteInvalido();

            // Act
            _clienteService.Add(cliente);

            // Assert
            _clienteTestsAutoMockerFixture.Mocker.GetMock<IClienteRepository>()
                .Verify(r => r.Add(cliente), Times.Never);
        }

        [Fact(DisplayName = "Obter Clientes Ativos")]
        [Trait("Categoria", "Cliente Service AutoMockFixture Tests")]
        public void ClienteService_ObterTodosAtivos_DeveRetornarApenasClientesAtivos()
        {
            // Arrange
            _clienteTestsAutoMockerFixture.Mocker.GetMock<IClienteRepository>()
                .Setup(c => c.GetAll())
                .Returns(_clienteTestsAutoMockerFixture.ObterClientesVariados());

            // Act
            var clientes = _clienteService.GetAllValidos();

            // Assert 
            Assert.True(clientes.Any());
            Assert.False(clientes.Count(c => !c.Valido) > 0);

            _outputHelper.WriteLine("Todos os clientes válidos foram obtidos!");
        }
    }
}