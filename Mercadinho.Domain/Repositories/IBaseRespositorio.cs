using System;
using System.Collections.Generic;

namespace Mercadinho.Domain.Repositories
{
    public interface IBaseRespositorio<T> : IDisposable where T : class, IEntidade
    {
        void Criar(T entidade);
        T SelecionarPorId(Guid id);
        IEnumerable<T> SelecionarTodos();
        void Atualizar(T entidade);
        void Excluir(Guid id);
    }
}
