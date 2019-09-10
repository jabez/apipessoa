using ApiPessoa.Dominio.Comum.Extensao;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiPessoa.Dominio.Pessoas
{
    internal class PessoaRegraDeNegocio : AbstractValidator<Pessoa>
    {
        private PessoaRegraDeNegocio()
        {
            UsarRegraIdentificador();
            UsarRegraNome();
            UsarRegraSexo();
            UsarRegraDataDeNascimento();
            UsarRegraCpf();
        }

        public static PessoaRegraDeNegocio Criar() => new PessoaRegraDeNegocio();

        #region Definição de Regras
        private void UsarRegraIdentificador() =>
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage($"{nameof(Pessoa)} - Identificador é obrigatório.");

        private void UsarRegraNome() =>
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage($"{nameof(Pessoa)} - Nome é obrigatório.")
                .MaximumLength(60).WithMessage($"{nameof(Pessoa)} - Nome deve ter no máximo 60 caracteres.");

        private void UsarRegraSexo() =>
            RuleFor(p => p.Sexo)
                .Must(sexo => sexo.ExisteNaEnum<Sexo>()).WithMessage($"{nameof(Pessoa)} - Sexo é inválido.");

        private void UsarRegraDataDeNascimento() =>
            RuleFor(p => p.DataNascimento)
                .Must(dataNascimento => dataNascimento.VerificarSeEMenorOuIgualA(DateTime.Now)).WithMessage($"{nameof(Pessoa)} - Data de nascimento é inválida.");

        private void UsarRegraCpf() =>
            RuleFor(p => p.Cpf)
                .Must(cpf => cpf.VerificarSeCpfEhValido()).WithMessage($"{nameof(Pessoa)} - Cpf é inválido.");
        #endregion
    }
}
