using System;
using System.Collections.Generic;
using System.Text;

namespace ApiPessoa.Dominio.Comum.Extensao
{
    public static class ObjetoExtensao
    {
        public static bool ENulo<T>(this T objeto) =>
            objeto == null;
    }
}
