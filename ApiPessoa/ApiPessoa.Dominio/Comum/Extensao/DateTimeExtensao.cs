using System;
using System.Collections.Generic;
using System.Text;

namespace ApiPessoa.Dominio.Comum.Extensao
{
    public static class DateTimeExtensao
    {
        /// <summary>
        /// Verifica se a data é menor ou igual a data de comparação.
        /// </summary>
        /// <param name="primeiraData"></param>
        /// <param name="segundaData"></param>
        /// <returns></returns>
        public static bool VerificarSeEMenorOuIgualA(this DateTime primeiraData, DateTime segundaData)
        {
            var resultado = DateTime.Compare(primeiraData, segundaData);

            if (resultado <= 0)
                return true;

            return false;
        }
    }
}
