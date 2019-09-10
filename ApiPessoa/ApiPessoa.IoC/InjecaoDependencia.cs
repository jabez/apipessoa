using ApiPessoa.IoC.InjecoesDependencia;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiPessoa.IoC
{
    public static class InjecaoDependencia
    {
        public static void AddInjecaoDependencia(this IServiceCollection servicos, IConfiguration configuracao)
        {
            PerfilMapeamento.Criar();
            servicos.AddCasoDeUso();
            servicos.AddRepositorio();
        }
    }
}
