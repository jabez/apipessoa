using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPessoa.API.Middleware.Erro
{
    /// <summary>
    ///  Dto utilizado para padronização no formato das msgs de erro.
    /// </summary>
    public class ErroDto
    {
        public IEnumerable<string> Mensagens { get; set; }
    }
}
