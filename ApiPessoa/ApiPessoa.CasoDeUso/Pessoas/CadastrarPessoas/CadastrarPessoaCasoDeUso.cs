using ApiPessoa.Aplicacao.CasosDeUso.Pessoas;
using ApiPessoa.Aplicacao.CasosDeUso.Pessoas.CadastrarPessoas;
using ApiPessoa.Aplicacao.Repositorio;
using ApiPessoa.Dominio.Pessoas;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiPessoa.CasosDeUso.Pessoas.CadastrarPessoas
{
    /// <summary>
    /// Implmentação da interface de cadastro de pessoa da camada de aplicação.
    /// </summary>
    public class CadastrarPessoaCasoDeUso : ICadastrarPessoaCasoDeUso
    {
        private readonly IRepositorio<Pessoa> _pessoaRepositorio;

        public CadastrarPessoaCasoDeUso(IRepositorio<Pessoa> pessoaRepositorio) => _pessoaRepositorio = pessoaRepositorio;

        /// <summary>
        /// Método utilizado para cadatrar uma pessoa na aplicação.
        /// </summary>
        /// <param name="pessoaDto"></param>
        /// <returns> Um PessoaView</returns>
        public PessoaView Cadastrar(PessoaDto pessoaDto)
        {
            var novaPessoa = Pessoa.Criar(pessoaDto.Nome, pessoaDto.DataNascimento, pessoaDto.Sexo.ToString(), pessoaDto.Cpf);
            _pessoaRepositorio.Adicionar(novaPessoa);
            return AutoMapper.Mapper.Map<PessoaView>(novaPessoa);
        }
    }
}
