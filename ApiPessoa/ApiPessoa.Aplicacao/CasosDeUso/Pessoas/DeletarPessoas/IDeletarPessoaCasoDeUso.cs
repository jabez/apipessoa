using System;
using System.Collections.Generic;
using System.Text;

namespace ApiPessoa.Aplicacao.CasosDeUso.Pessoas.DeletarPessoas
{
    /// <summary>
    /// Interface para exclusão de pessoa.
    /// </summary>
    public interface IDeletarPessoaCasoDeUso
    {
        /// <summary>
        /// Exclui uma pessoa da aplicação.
        /// </summary>
        /// <param name="id"></param>
        void Deletar(string id);
    }
}
