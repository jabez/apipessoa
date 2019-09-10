using System;
using System.Collections.Generic;
using System.Text;

namespace ApiPessoa.Aplicacao.CasosDeUso.Pessoas.ObterPessoas
{
    /// <summary>
    /// Interface para obter Pessoa.
    /// </summary>
    public interface IObterPessoaCasoDeUso
    {
        /// <summary>
        /// Obtém uma pessoa através do Id informado.
        /// </summary>
        /// <param name="id"></param>
        PessoaView ObterPessoaPorId(string id);

        /// <summary>
        /// Obtêm todas as pessoas.
        /// </summary>
        /// <returns></returns>
        IEnumerable<PessoaView> ObterPessoas();
    }
}
