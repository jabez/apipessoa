using System;
using System.Collections.Generic;
using System.Text;

namespace ApiPessoa.Aplicacao.CasosDeUso.Pessoas.CadastrarPessoas
{
    /// <summary>
    /// Interface de cadastro de pessoa.
    /// </summary>
    public interface ICadastrarPessoaCasoDeUso
    {
        /// <summary>
        /// Cadastra uma pessoa na aplicação.
        /// </summary>
        /// <param name="pessoaDto"></param>
        /// <returns></returns>
        PessoaView Cadastrar(PessoaDto pessoaDto);
    }
}
