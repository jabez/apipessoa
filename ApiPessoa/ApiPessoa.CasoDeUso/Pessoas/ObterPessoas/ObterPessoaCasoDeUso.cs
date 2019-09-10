using ApiPessoa.Aplicacao.CasosDeUso.Comum.Exception;
using ApiPessoa.Aplicacao.CasosDeUso.Pessoas;
using ApiPessoa.Aplicacao.CasosDeUso.Pessoas.ObterPessoas;
using ApiPessoa.Aplicacao.Repositorio;
using ApiPessoa.Dominio.Comum.Extensao;
using ApiPessoa.Dominio.Pessoas;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiPessoa.CasosDeUso.Pessoas.ObterPessoas
{
    /// <summary>
    /// Implementação da Interface para obter Pessoa.
    /// </summary>
    public class ObterPessoaCasoDeUso : IObterPessoaCasoDeUso
    {
        private readonly IRepositorio<Pessoa> _pessoaRepositorio;

        public ObterPessoaCasoDeUso(IRepositorio<Pessoa> pessoaRepositorio) => _pessoaRepositorio = pessoaRepositorio;

        /// <summary>
        /// Obtém uma pessoa através do Id informado.
        /// </summary>
        /// <param name="id"></param>
        public PessoaView ObterPessoaPorId(string id)
        {
            var pessoa = _pessoaRepositorio.Obter(new Guid(id));
            if (pessoa.ENulo())
                throw new RecursoNaoEncontradoException("Pessoa não encontrada");

            return AutoMapper.Mapper.Map<PessoaView>(pessoa);
        }

        /// <summary>
        /// Obtêm todas as pessoas.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PessoaView> ObterPessoas()
        {
            var pessoas = _pessoaRepositorio.Listar();
            if(pessoas.ENuloOuVazio())
                throw new RecursoNaoEncontradoException("Pessoas não encontradas");

            return AutoMapper.Mapper.Map<IEnumerable <Pessoa>,IEnumerable <PessoaView>>(pessoas);
        }
    }
}
