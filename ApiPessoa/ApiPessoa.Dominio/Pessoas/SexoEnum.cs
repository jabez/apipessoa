using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ApiPessoa.Dominio.Pessoas
{
    public enum Sexo
    {
        [Description("Masculino")]
        Masculino = 0,
        [Description("Feminino")]
        Feminino = 1
    }
}
