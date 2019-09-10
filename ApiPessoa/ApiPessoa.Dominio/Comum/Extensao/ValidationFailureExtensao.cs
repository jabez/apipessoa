using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiPessoa.Dominio.Comum.Extensao
{
    internal static class ValidationFailureExtensao
    {
        /// <summary>
        /// Retorna uma lista de mensagens erros.
        /// </summary>
        /// <param name="erros"></param>
        /// <returns></returns>
        public static IEnumerable<string> GerarMensagens(this IList<ValidationFailure> erros)
        {
            var mensagens = new List<string>();
            foreach (var erro in erros)
                mensagens.Add(erro.ErrorMessage);
            return mensagens;
        }
    }
}
