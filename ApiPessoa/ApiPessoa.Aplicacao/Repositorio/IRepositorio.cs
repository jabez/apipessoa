using ApiPessoa.Dominio.Comum.RaizAgregacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiPessoa.Aplicacao.Repositorio
{
    public interface IRepositorio<T> where T : IRaizAgregacao
    {
        IEnumerable<T> Listar();
        void Adicionar(T entidade);
        void Atualizar(T entidade);
        void Remover(T entidade);
        T Obter(Guid id);
    }
}
