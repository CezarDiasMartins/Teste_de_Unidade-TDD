using System;
using System.Collections.Generic;

namespace Demo.Clientes
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Valido { get; set; }
        public List<string> Errors { get; set; }

        public Cliente(int id, string nome, bool valido)
        {
            Id = id;
            Nome = Nome;
            DataCadastro = DateTime.Now;
            Valido = valido;
            Errors = new List<string>();
        }

        public Cliente(string nome, bool valido)
        {
            Nome = Nome;
            DataCadastro = DateTime.Now;
            Valido = valido;
            Errors = new List<string>();
        }

        public bool EhValido(Cliente cliente)
        {
            if (cliente.Valido) return true;
            else return false;
        }
    }
}