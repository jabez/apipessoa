using ApiPessoa.Aplicacao.CasosDeUso.Comum.Exception;
using ApiPessoa.Aplicacao.CasosDeUso.Pessoas.DeletarPessoas;
using ApiPessoa.Aplicacao.Repositorio;
using ApiPessoa.Dominio.Comum.Extensao;
using ApiPessoa.Dominio.Pessoas;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiPessoa.CasosDeUso.Pessoas.DeletarPessoas
{
    /// <summary>
    /// Implementação da interface de exclusão de pessoa da camada de aplicação.
    /// </summary>
    public class DeletarPessoaCasoDeUso : IDeletarPessoaCasoDeUso
    {
        private readonly IRepositorio<Pessoa> _pessoaRepositorio;

        public DeletarPessoaCasoDeUso (IRepositorio<Pessoa> pessoaRepositorio) => _pessoaRepositorio = pessoaRepositorio;

        /// <summary>
        /// Exclui uma pessoa da aplicação.
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(string id)
        {
            var pessoa = ObterPessoa(id);
            if (pessoa.ENulo())
                throw new RecursoNaoEncontradoException("Pessoa não encontrada");

            _pessoaRepositorio.Remover(pessoa);
        }

        private Pessoa ObterPessoa(string id) =>  _pessoaRepositorio.Obter(new Guid(id));
        
    }
}
