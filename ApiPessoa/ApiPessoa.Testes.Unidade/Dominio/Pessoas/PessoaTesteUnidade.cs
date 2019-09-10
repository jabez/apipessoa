using ApiPessoa.Aplicacao.CasosDeUso.Pessoas.CadastrarPessoas;
using ApiPessoa.Dominio.Comum.Exception;
using ApiPessoa.Dominio.Pessoas;
using ApiPessoa.Testes.Compartilhado.Builders.Dominio.Pessoas;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;
using Sexo = ApiPessoa.Aplicacao.CasosDeUso.Pessoas.CadastrarPessoas.Sexo;

namespace ApiPessoa.Testes.Unidade.Dominio.Pessoas
{
    public class PessoaTesteUnidade : TesteUnidade
    {
        private readonly PessoaDto _pessoaDto;

        public PessoaTesteUnidade() => _pessoaDto = PessoaDtoBuilder.Criar();

        [Fact(DisplayName = "Deve criar uma pessoa válida.")]
        public void DeveCriarPessoa()
        {
            var pessoa = Pessoa.Criar(nome: _pessoaDto.Nome, dataNascimento: _pessoaDto.DataNascimento, sexo: _pessoaDto.Sexo.ToString(), cpf: _pessoaDto.Cpf);

            pessoa.Should().NotBeNull();
            pessoa.Id.Should().NotBeEmpty();
            pessoa.Nome.Should().Be(_pessoaDto.Nome);
            pessoa.DataNascimento.Should().Be(_pessoaDto.DataNascimento);
            pessoa.Sexo.ToString().Should().Be(_pessoaDto.Sexo.ToString());
            pessoa.Cpf.Should().Be(_pessoaDto.Cpf);
        }

        [Theory(DisplayName = "Não deve validar caso nome seja inválido.")]
        [InlineData(null,"Pessoa - Nome é obrigatório.")]
        [InlineData("", "Pessoa - Nome é obrigatório.")]
        public void NaoDeveValidarCasoNomeSejaInvalido(string valor, string motivo)
        {
            var mensagensErro = new List<string>() {
                motivo
            };
            _pessoaDto.Nome = valor;
            ValidarRegraDeNegocioException(mensagensErro, _pessoaDto);
        }

        [Fact(DisplayName = "Não deve validar caso nome tenha tamanho maior que o permitido.")]
        public void NaoDeveValidarCasoNomeSejaMaiorQuePermitido()
        {
            var mensagensErro = new List<string>() {
                "Pessoa - Nome deve ter no máximo 60 caracteres."
            };
            _pessoaDto.Nome = new string ('x',61);
            ValidarRegraDeNegocioException(mensagensErro, _pessoaDto);
        }

        [Fact(DisplayName = "Não deve validar caso sexo seja inválido.")]
        public void NaoDeveValidarCasoSexoSejaInvalido()
        {
            var mensagensErro = new List<string>() {
                "Pessoa - Sexo é inválido."
            };
            _pessoaDto.Sexo = (Sexo)45;
            ValidarRegraDeNegocioException(mensagensErro, _pessoaDto);
        }

        [Fact(DisplayName = "Não deve validar caso a data de nascimento seja inválida.")]
        public void NaoDeveValidarCasoDataDeNascimentoSejaInvalida()
        {
            var mensagensErro = new List<string>() {
                "Pessoa - Data de nascimento é inválida."
            };
            _pessoaDto.DataNascimento = DateTime.Now.AddYears(1);
            ValidarRegraDeNegocioException(mensagensErro, _pessoaDto);
        }

        [Fact(DisplayName = "Não deve validar caso o cpf seja inválido.")]
        public void NaoDeveValidarCasoCpfSejaInvalido()
        {
            var mensagensErro = new List<string>() {
                "Pessoa - Cpf é inválido."
            };
            _pessoaDto.Cpf = "1234568789";
            ValidarRegraDeNegocioException(mensagensErro, _pessoaDto);
        }
        private void ValidarRegraDeNegocioException(List<string> mensagensErro, PessoaDto pessoaDto)
        {
            Action acaoCriada = () =>
                Pessoa.Criar(nome: null, dataNascimento: _pessoaDto.DataNascimento, sexo: _pessoaDto.Sexo.ToString(), cpf: _pessoaDto.Cpf);
           
           acaoCriada.Should().Throw<RegraDeNegocioException>(mensagensErro[0]);
        }
    }
}
