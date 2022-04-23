using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mercadinho.Domain.Repositories
{
    public interface IBaseRespositorio<T> : IDisposable where T : class, IEntity
    {
        void Criar(T entidade);
        T SelecionarPorId(int id);
        IEnumerable<T> SelecionarTodos();
        void Atualizar(T entidade);
        void Excluir(int id);
    }
}
