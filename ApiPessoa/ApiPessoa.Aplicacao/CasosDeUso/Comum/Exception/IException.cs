﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ApiPessoa.Aplicacao.CasosDeUso.Comum.Exception
{
    public interface IException
    {
        IEnumerable<string> MensagensErro { get; }
    }
}
