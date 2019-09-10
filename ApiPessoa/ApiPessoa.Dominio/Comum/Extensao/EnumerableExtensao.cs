using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiPessoa.Dominio.Comum.Extensao
{
    public static class EnumerableExtensao
    {
        public static bool ENuloOuVazio<T>(this IEnumerable<T> dados) =>
            dados?.Any() != true;
    }
}
