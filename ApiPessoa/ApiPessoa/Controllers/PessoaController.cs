using ApiPessoa.API.ApiConventions;
using ApiPessoa.Aplicacao.CasosDeUso.Pessoas;
using ApiPessoa.Aplicacao.CasosDeUso.Pessoas.CadastrarPessoas;
using ApiPessoa.Aplicacao.CasosDeUso.Pessoas.DeletarPessoas;
using ApiPessoa.Aplicacao.CasosDeUso.Pessoas.ObterPessoas;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[assembly: ApiConventionType(typeof(SwaggerCustomConventions))]
namespace ApiPessoa.API.Controllers
{
    /// <summary>
    /// Define os endpoints do CRUD de pessoas.
    /// </summary>
    [Route("v{versao:apiVersion}/pessoas")]
    [ApiController]
    public class PessoaController : ControllerBase
    {

        private readonly ICadastrarPessoaCasoDeUso _cadastrarPessoaCasoDeUso;
        private readonly IObterPessoaCasoDeUso _obterPessoaCasoDeUso;
        private readonly IDeletarPessoaCasoDeUso _deletarPessoaCasoDeUso;

        /// <summary>
        /// Cria uma instancia com os parâmetros informados
        /// </summary>
        /// <param name="cadastrarPessoaCasoDeUso"></param>
        /// <param name="obterPessoaCasoDeUso"></param>
        /// <param name="deletarPessoaCasoDeUso"></param>
        public PessoaController(ICadastrarPessoaCasoDeUso cadastrarPessoaCasoDeUso, IObterPessoaCasoDeUso obterPessoaCasoDeUso, IDeletarPessoaCasoDeUso deletarPessoaCasoDeUso)
        {
            _cadastrarPessoaCasoDeUso = cadastrarPessoaCasoDeUso;
            _obterPessoaCasoDeUso = obterPessoaCasoDeUso;
            _deletarPessoaCasoDeUso = deletarPessoaCasoDeUso;
        }

        /// <summary>
        /// Cadastra uma nova pessoa
        /// </summary>        
        /// <remarks>Cadastrar uma nova pessoa.</remarks>
        /// <response code="201">pessoa cadastrada.</response>               
        /// <response code="422">Erro de negócio.</response>
        /// <response code="500">Erro interno do servidor.</response>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<PessoaView> Cadastrar([FromBody] PessoaDto pessoaDto)
        {
            return Created("v{versao:apiVersion}/pessoas", _cadastrarPessoaCasoDeUso.Cadastrar(pessoaDto));
        }

        /// <summary>
        /// Obter todas as pessoas.
        /// </summary>        
        /// <remarks>Obtem todas as pessoas cadastradas.</remarks>
        /// <response code="200">OK</response>       
        /// <response code="404">Recurso não encontrado.</response>        
        /// <response code="422">Erro de negócio.</response>
        /// <response code="500">Erro interno do servidor.</response>
        /// <returns></returns>
        [HttpGet]
        /*[ProducesResponseType(200, Type = typeof(PessoaView))]
        [ProducesResponseType(404, Type = typeof(ErroDto))]
        [ProducesResponseType(422, Type = typeof(ErroDto))]
        [ProducesResponseType(500, Type = typeof(ErroDto))]*/
        public ActionResult<IEnumerable<PessoaView>> Obter() =>
            Ok(_obterPessoaCasoDeUso.ObterPessoas());

        /// <summary>
        /// Obter pessoa por Id.
        /// </summary>        
        /// <remarks>Obtem uma pessoa por Id.</remarks>
        /// <response code="200">OK</response>       
        /// <response code="404">Recurso não encontrado.</response>        
        /// <response code="422">Erro de negócio.</response>
        /// <response code="500">Erro interno do servidor.</response>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<PessoaView> ObterPorId([FromRoute(Name = "id")]string idPessoa) =>
            Ok(_obterPessoaCasoDeUso.ObterPessoaPorId(idPessoa));

        /// <summary>
        /// Deletar uma pessoa por Id.
        /// </summary>        
        /// <remarks>Deleta uma pessoa por Id.</remarks>
        /// <response code="200">OK</response>       
        /// <response code="404">Recurso não encontrado.</response>        
        /// <response code="422">Erro de negócio.</response>
        /// <response code="500">Erro interno do servidor.</response>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult<string> Deletar([FromRoute(Name = "id")]string idPessoa)
        {
            _deletarPessoaCasoDeUso.Deletar(idPessoa);
            return Ok("Pessoa deletada com sucesso");
        }
    }
}
