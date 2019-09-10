using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiPessoa.Dominio.Comum.Extensao
{
   public static class CpfExtensao
    {
        /// <summary>
        /// Verifica se o cpf possui o tamanho válido.
        /// </summary>
        /// <param name="NumeroDocumento"></param>
        /// <returns></returns>
        public static bool VerificarSeCpfEhValido(this string NumeroDocumento) =>
           !NumeroDocumento.VerificarSeEhNuloOuVazio() && NumeroDocumento.VerificarSeEhNumerico() && (NumeroDocumento.Length == 11 );
    }
}
