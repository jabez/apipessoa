using ApiPessoa.Aplicacao.CasosDeUso.Pessoas.CadastrarPessoas;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiPessoa.Testes.Compartilhado.Builders.Dominio.Pessoas
{
    public class PessoaDtoBuilder : Builder<PessoaDto>
    {
        public static PessoaDto Criar() =>
                new PessoaDtoBuilder().Instanciar();

        public override PessoaDto Instanciar() =>
            new PessoaDto()
            {
                Nome = "joao da silva",
                Cpf = "12345678952",
                DataNascimento = DateTime.Now.AddYears(-28),
                Sexo = Sexo.Masculino
            };
    }
}
