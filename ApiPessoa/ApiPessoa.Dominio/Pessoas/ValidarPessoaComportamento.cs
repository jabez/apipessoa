using ApiPessoa.Dominio.Comum.Extensao;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiPessoa.Dominio.Pessoas
{
    internal static class ValidarPessoaComportamento
    {
        public static void Validar(this Pessoa pessoa) =>
            PessoaRegraDeNegocio.Criar().Validate(pessoa).Verificar();
    }
}
