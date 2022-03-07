using Mercadinho.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace Mercadinho.Data.Repositories
{
    public class BaseRepositorio<T> : IBaseRespositorio<T> where T : class, IEntidade
    {
        public void Atualizar(T entidade)
        {
            throw new NotImplementedException();
        }

        public void Criar(T entidade)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Excluir(Guid id)
        {
            throw new NotImplementedException();
        }

        public T SelecionarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
