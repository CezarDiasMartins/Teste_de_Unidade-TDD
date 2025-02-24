﻿using DemoTDD.Pedidos;

namespace DemoTDD.Tests
{
    public class PedidoItemTests
    {
        [Fact(DisplayName = "Novo Item Pedido com unidades abaixo do permitido")]
        [Trait("Categoria", "Vendas - Pedido Item")]
        public void NovoItemPedido_UnidadesItemAbaixodoPermitido_DeveRetornarException()
        {
            // Arrange Act & Assert
            Assert.Throws<DomainException>(() => new PedidoItem(Guid.NewGuid(), "Produto Teste", Pedido.MIN_UNIDADES_ITEM - 1, 100));
        }
    }
}