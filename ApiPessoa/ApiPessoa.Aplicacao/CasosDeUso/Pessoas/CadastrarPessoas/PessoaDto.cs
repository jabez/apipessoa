using System;
using System.Collections.Generic;
using System.Text;

namespace ApiPessoa.Aplicacao.CasosDeUso.Pessoas.CadastrarPessoas
{
    public class PessoaDto
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Sexo Sexo { get; set; }
        public string Cpf { get; set; }
    }
}
