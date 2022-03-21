using Mercadinho.Application.ViewModel;
using System;
using System.Collections.Generic;

namespace Mercadinho.Application.Interface
{
    public interface IItemCarrinhoAplicacao
    {
        void Incluir(ItemCarrinhoViewModel entidade);
        IEnumerable<ItemCarrinhoViewModel> SelecionarTodos();
        ItemCarrinhoViewModel SelecionarPorId(Guid id);
        void Excluir(Guid id);
        void Atualizar(ItemCarrinhoViewModel entidade);
    }
}
