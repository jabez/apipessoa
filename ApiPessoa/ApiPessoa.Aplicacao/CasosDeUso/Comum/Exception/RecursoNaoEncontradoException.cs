using System;
using System.Collections.Generic;
using System.Text;

namespace ApiPessoa.Aplicacao.CasosDeUso.Comum.Exception
{
    public class RecursoNaoEncontradoException : System.Exception, IException
    {
        public IEnumerable<string> MensagensErro { get; }

        public RecursoNaoEncontradoException(string mensagem) =>
            MensagensErro = new List<string>() { mensagem };

        public RecursoNaoEncontradoException(IEnumerable<string> mensagens) =>
            MensagensErro = mensagens;
    }
}
