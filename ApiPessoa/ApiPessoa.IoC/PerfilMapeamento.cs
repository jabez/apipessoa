using ApiPessoa.CasosDeUso.Pessoas;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiPessoa.IoC
{
    public static class PerfilMapeamento
    {
        public static void Criar() => Mapper.Initialize(cfg =>
        {
            cfg.AddProfile(new PessoaDtoPerfil());
        });
    }
}
