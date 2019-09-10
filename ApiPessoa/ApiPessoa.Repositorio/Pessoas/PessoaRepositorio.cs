using ApiPessoa.Aplicacao.Repositorio;
using ApiPessoa.Dominio.Pessoas;
using ApiPessoa.Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiPessoa.Repositorio.Pessoas
{
    public class PessoaRepositorio : IRepositorio<Pessoa>
    {
        private readonly ApiPessoaContexto _apiPessoaContexto;

        public PessoaRepositorio(ApiPessoaContexto apiPessoaContexto) => _apiPessoaContexto = apiPessoaContexto;

        public void Adicionar(Pessoa entidade)
        {
            _apiPessoaContexto.Pessoa.Add(entidade);
            _apiPessoaContexto.SaveChanges();
        }

        public void Atualizar(Pessoa entidade)
        {
            _apiPessoaContexto.Pessoa.Update(entidade);
            _apiPessoaContexto.SaveChanges();
        }
        public IEnumerable<Pessoa> Listar() => _apiPessoaContexto.Pessoa.ToList();

        public Pessoa Obter(Guid id) => _apiPessoaContexto.Pessoa.FirstOrDefault(x => x.Id == id);

        public void Remover(Pessoa entidade)
        {
            _apiPessoaContexto.Pessoa.Remove(entidade);
            _apiPessoaContexto.SaveChanges();
        }
    }
}
