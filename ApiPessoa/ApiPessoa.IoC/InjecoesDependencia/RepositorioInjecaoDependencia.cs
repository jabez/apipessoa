using ApiPessoa.Aplicacao.Repositorio;
using ApiPessoa.Dominio.Pessoas;
using ApiPessoa.Repositorio.Pessoas;
using Microsoft.Extensions.DependencyInjection;

namespace ApiPessoa.IoC.InjecoesDependencia
{
    internal static class RepositorioInjecaoDependencia
    {
        public static void AddRepositorio(this IServiceCollection servicos)
        {
            servicos.AddScoped<IRepositorio<Pessoa>, PessoaRepositorio>();
        }
    }
}
