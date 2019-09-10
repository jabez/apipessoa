using ApiPessoa.Aplicacao.CasosDeUso.Comum.Exception;
using ApiPessoa.Dominio.Comum.Exception;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ApiPessoa.API.Middleware.Erro
{
    /// <summary>
    /// Faz a interceptação dos erros e o tratamento. 
    /// </summary>
    public class ErroMiddleware
    {
        private readonly RequestDelegate _next;
        /// <summary>
        /// Cria uma instancia com os parâmetros informados
        /// </summary>
        /// <param name="next"></param>
        public ErroMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Faz o tratamento dos erros.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (RecursoNaoEncontradoException recursoNaoEncontradoException)
            {
                await HandleExceptionAsync(context, recursoNaoEncontradoException.MensagensErro, HttpStatusCode.NotFound);
            }
            catch (RegraDeNegocioException regraDeNegocioException)
            {
                await HandleExceptionAsync(context, regraDeNegocioException.MensagensErro, HttpStatusCode.UnprocessableEntity);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, new List<string> { exception.Message }, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Retorna um Json com o erro.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mensagensErro"></param>
        /// <param name="httpStatusCode"></param>
        /// <returns></returns>
        public Task HandleExceptionAsync(HttpContext context, IEnumerable<string> mensagensErro, HttpStatusCode httpStatusCode)
        {
            var erro = new ErroDto { Mensagens = mensagensErro };
            var resultado = JsonConvert.SerializeObject(erro, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)httpStatusCode;
            return context.Response.WriteAsync(resultado);
        }

    }
}
