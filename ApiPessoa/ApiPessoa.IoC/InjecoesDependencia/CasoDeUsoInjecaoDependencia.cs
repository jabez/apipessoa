using ApiPessoa.Aplicacao.CasosDeUso.Pessoas.CadastrarPessoas;
using ApiPessoa.Aplicacao.CasosDeUso.Pessoas.DeletarPessoas;
using ApiPessoa.Aplicacao.CasosDeUso.Pessoas.ObterPessoas;
using ApiPessoa.CasosDeUso.Pessoas;
using ApiPessoa.CasosDeUso.Pessoas.CadastrarPessoas;
using ApiPessoa.CasosDeUso.Pessoas.DeletarPessoas;
using ApiPessoa.CasosDeUso.Pessoas.ObterPessoas;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiPessoa.IoC.InjecoesDependencia
{
    internal static class CasoDeUsoInjecaoDependencia
    {
        public static void AddCasoDeUso(this IServiceCollection servicos)
        {
            servicos.AddScoped<ICadastrarPessoaCasoDeUso, CadastrarPessoaCasoDeUso>();
            servicos.AddScoped<IObterPessoaCasoDeUso, ObterPessoaCasoDeUso>();
            servicos.AddScoped<IDeletarPessoaCasoDeUso, DeletarPessoaCasoDeUso>();
        }
    }
}
