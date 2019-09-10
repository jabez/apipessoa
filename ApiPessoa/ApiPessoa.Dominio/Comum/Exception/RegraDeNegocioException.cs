using System;
using System.Collections.Generic;
using System.Text;

namespace ApiPessoa.Dominio.Comum.Exception
{
    public class RegraDeNegocioException : System.Exception, IException
    {
        public IEnumerable<string> MensagensErro { get; }

        public RegraDeNegocioException(string mensagem) =>
            MensagensErro = new List<string>() { mensagem };

        public RegraDeNegocioException(IEnumerable<string> mensagens) =>
            MensagensErro = mensagens;
    }
}
