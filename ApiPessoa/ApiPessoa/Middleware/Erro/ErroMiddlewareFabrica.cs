using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPessoa.API.Middleware.Erro
{
    /// <summary>
    /// Fabrica de Middleware de erro.
    /// </summary>
    public static class ErroMiddlewareFabrica
    {
        public static IApplicationBuilder UseErro(this IApplicationBuilder applicationBuilder) =>
            applicationBuilder.UseMiddleware<ErroMiddleware>();
    }
}
