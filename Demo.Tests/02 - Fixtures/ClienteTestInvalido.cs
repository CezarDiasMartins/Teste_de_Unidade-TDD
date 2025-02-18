using Demo.Tests.Fixtures;
using static Demo.Tests.Fixtures.ClienteTestsFixture;

namespace Demo.Fixtures
{
    [Collection(nameof(ClienteCollection))]
    public class ClienteTestInvalido
    {
        private readonly ClienteTestsFixture _clienteTestsfixture;
        public ClienteTestInvalido(ClienteTestsFixture clienteTestsfixture)
        {
            _clienteTestsfixture = clienteTestsfixture;
        }

        [Fact(DisplayName = "Validar Cliente")]
        [Trait("Cliente", "Invalido")]
        public void Cliente_Validar_ClienteInvalido()
        {
            // Arange
            var cliente = _clienteTestsfixture.GerarClienteInvalido();

            // Act
            var result = cliente.EhValido(cliente);
            if (!result) cliente.Errors.Add("Cliente Inválido!");

            // Assert
            Assert.False(result);
            Assert.NotEqual(0, cliente.Errors.Count);
        }
    }
}