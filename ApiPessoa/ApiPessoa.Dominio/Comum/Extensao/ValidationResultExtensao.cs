using ApiPessoa.Dominio.Comum.Exception;
using FluentValidation.Results;

namespace ApiPessoa.Dominio.Comum.Extensao
{
    internal static class ValidationResultExtensao
    {
        /// <summary>
        /// Verifica se todas as regras definidas foram atendidas. 
        /// </summary>
        /// <param name="validacao"></param>
        public static void Verificar(this ValidationResult validacao)
        {
            if (!validacao.IsValid)
                throw new RegraDeNegocioException(validacao.Errors.GerarMensagens());
        }
    }
}
