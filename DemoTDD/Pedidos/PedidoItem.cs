﻿using System;

namespace DemoTDD.Pedidos
{
    public class PedidoItem
    {
        public Guid PedidoId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public string ProdutoNome { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }

        public Pedido Pedido { get; set; }

        public PedidoItem(Guid produtoId, string produtoNome, int quantidade, decimal valorUnitario)
        {
            if (quantidade < Pedido.MIN_UNIDADES_ITEM) throw new DomainException($"Mínimo de {Pedido.MIN_UNIDADES_ITEM} unidades por produto");

            ProdutoId = produtoId;
            ProdutoNome = produtoNome;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }
        protected PedidoItem() { }

        public void AssociarPedido(Guid pedidoId)
        {
            PedidoId = pedidoId;
        }

        public decimal CalcularValor()
        {
            return Quantidade * ValorUnitario;
        }

        public void AdicionarUnidades(int unidades)
        {
            Quantidade += unidades;
        }

        public void AtualizarUnidades(int unidades)
        {
            Quantidade = unidades;
        }
    }
}