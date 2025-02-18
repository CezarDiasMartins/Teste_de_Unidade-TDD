using Demo.Tests.Fixtures;
using static Demo.Tests.Fixtures.ClienteTestsFixture;

namespace Demo.Fixtures
{
    [Collection(nameof(ClienteCollection))]
    public class ClienteTestValido
    {
        private readonly ClienteTestsFixture _clienteTestsfixture;
        public ClienteTestValido(ClienteTestsFixture clienteTestsfixture)
        {
            _clienteTestsfixture = clienteTestsfixture;
        }

        [Fact(DisplayName = "Validar Cliente")]
        [Trait("Cliente", "Valido")]
        public void Cliente_Validar_ClienteValido()
        {
            // Arange
            var cliente = _clienteTestsfixture.GerarClienteValido();

            // Act
            var result = cliente.EhValido(cliente);
            if (!result) cliente.Errors.Add("Cliente Inválido!");

            // Assert
            Assert.True(result);
            Assert.Equal(0, cliente.Errors.Count);
        }
    }
}