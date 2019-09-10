using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ApiPessoa.API.Configuracao
{
    public static class ConfiguracaoFabrica
    {
        public static IConfigurationRoot Criar() =>
            Criar(null);

        public static IConfigurationRoot Criar(IHostingEnvironment env = null) =>
            new ConfigurationBuilder()
                .SetBasePath(env != null ? env.ContentRootPath : Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
    }
}
