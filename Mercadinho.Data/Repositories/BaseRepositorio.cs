using Mercadinho.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mercadinho.Data.Repositories
{
    public class BaseRepositorio<T> : IBaseRespositorio<T> where T : class, IEntity
    {

        private readonly Contexto _contexto;
        public BaseRepositorio(Contexto contexto)
            => _contexto = contexto;

        public void Atualizar(T entidade)
        {
            _contexto.Set<T>().Update(entidade);
            _contexto.SaveChanges();
        }

        public void Criar(T entidade)
        {
            _contexto.Set<T>().Add(entidade);
            _contexto.SaveChanges();
        }

        public T SelecionarPorId(Guid id)
            => _contexto.Set<T>().FirstOrDefault(x => x.Id == id);

        public IEnumerable<T> SelecionarTodos()
            => _contexto.Set<T>().ToList();

        public void Excluir(Guid id)
        {
            var entidade = SelecionarPorId(id);
            _contexto.Set<T>().Remove(entidade);
            _contexto.SaveChanges();
        }

        public void Dispose()
            => _contexto.Dispose();

    }
}