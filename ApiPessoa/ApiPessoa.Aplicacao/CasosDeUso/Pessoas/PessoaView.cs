using System;
using System.Collections.Generic;
using System.Text;

namespace ApiPessoa.Aplicacao.CasosDeUso.Pessoas
{
    public class PessoaView
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Cpf { get; set; }
    }
}
