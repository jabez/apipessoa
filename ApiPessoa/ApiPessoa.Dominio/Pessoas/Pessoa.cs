using ApiPessoa.Dominio.Comum.RaizAgregacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiPessoa.Dominio.Pessoas
{
    public partial class Pessoa : IRaizAgregacao
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Sexo Sexo { get; private set; }
        public string Cpf { get; private set; }

        protected Pessoa() { }
    }
}
