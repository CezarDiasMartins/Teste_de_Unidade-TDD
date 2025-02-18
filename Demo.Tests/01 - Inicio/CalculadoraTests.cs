namespace Demo.Inicio
{
    public class CalculadoraTests1
    {
        [Fact(DisplayName = "Soma Valor Teste 1")]
        [Trait("Categoria", "Soma1")]
        public void Calculadora_Somar_RetornarValorSoma()
        {
            // Arrange
            var calculadora = new Calculadora();

            // Act
            var resutlado = calculadora.Somar(2, 2);

            // Assert
            Assert.Equal(4, resutlado);
        }

        [Theory]
        [Trait("Categoria", "Soma1")]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]
        [InlineData(4, 3, 7)]
        [InlineData(-1, 1, 0)]
        [InlineData(-1, -1, -2)]
        public void teste(double v1, double v2, double total)
        {
            // Arrange
            var calculadora = new Calculadora();

            // Act
            var resutlado = calculadora.Somar(v1, v2);

            // Assert
            Assert.Equal(total, resutlado);
        }
    }

    public class CalculadoraTests2
    {
        public Calculadora calculadora;
        public CalculadoraTests2()
        {
            calculadora = new Calculadora();
            // calculadora = new Calculadora(a, b, c, ...);
        }

        [Fact(DisplayName = "Soma Valor Teste 2")]
        [Trait("Categoria", "Soma2")]
        public void Calculadora_Somar_RetornarValorSoma()
        {
            // Act
            var resutlado = calculadora.Somar(2, 2);

            // Assert
            Assert.Equal(4, resutlado);
        }

        [Theory]
        [Trait("Categoria", "Soma2")]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]
        [InlineData(4, 3, 7)]
        [InlineData(-1, 1, 0)]
        [InlineData(-1, -1, -2)]
        public void teste(double v1, double v2, double total)
        {
            // Act
            var resutlado = calculadora.Somar(v1, v2);

            // Assert
            Assert.Equal(total, resutlado);
        }
    }
}