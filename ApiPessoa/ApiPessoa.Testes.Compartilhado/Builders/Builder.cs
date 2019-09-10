using Microsoft.EntityFrameworkCore;
using System;

namespace ApiPessoa.Testes.Compartilhado.Builders
{
    public abstract class Builder<T> where T : class
    {
        public abstract T Instanciar();
        protected virtual void CriarDependencias(DbContext context) { }

        public T Criar(DbContext context)
        {
            CriarDependencias(context);

            var entity = Instanciar();
            context.Set<T>().Add(entity);
            try
            {
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao criar contexto de banco de dados:", e);
            }

            return entity;
        }
    }
}
