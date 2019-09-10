using ApiPessoa.Dominio.Comum.RaizAgregacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiPessoa.Dominio.Pessoas
{
    public partial class Pessoa : IRaizAgregacao
    {
        /// <summary>
        /// Cria um objeto do tipo Pessoa.
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="dataNascimento"></param>
        /// <param name="sexo"></param>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public static Pessoa Criar(string nome, DateTime dataNascimento, string sexo, string cpf)
        {
            var pessoa = new Pessoa()
            {
                Id = Guid.NewGuid(),
                Nome = nome,
                DataNascimento = dataNascimento,
                Sexo = (Sexo)Enum.Parse(typeof(Sexo),sexo),
                Cpf = cpf
            };
            pessoa.Validar();
            return pessoa;
        }
    }
}
