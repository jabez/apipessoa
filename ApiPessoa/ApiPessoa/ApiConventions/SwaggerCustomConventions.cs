using ApiPessoa.API.Middleware.Erro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace ApiPessoa.API.ApiConventions
{
    public static class SwaggerCustomConventions
    {
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(404, Type = typeof(ErroDto))]
        [ProducesResponseType(422, Type = typeof(ErroDto))]
        [ProducesResponseType(500, Type = typeof(ErroDto))]
        public static void Obter(params object [] parametros){ }

        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(422, Type = typeof(ErroDto))]
        [ProducesResponseType(500, Type = typeof(ErroDto))]
        public static void Cadastrar(params object[] parametros) { }

        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(404, Type = typeof(ErroDto))]
        [ProducesResponseType(422, Type = typeof(ErroDto))]
        [ProducesResponseType(500, Type = typeof(ErroDto))]
        public static void Deletar(params object[] parametros) { }
    }
}
