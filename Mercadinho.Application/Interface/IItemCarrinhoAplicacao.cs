using Mercadinho.Application.ViewModel;
using System;
using System.Collections.Generic;

namespace Mercadinho.Application.Interface
{
    public interface IItemCarrinhoAplicacao
    {
        void Incluir(ItemCarrinhoViewModel entidade);
        IEnumerable<ItemCarrinhoViewModel> SelecionarTodos();
        ItemCarrinhoViewModel SelecionarPorId(int id);
        void Excluir(int id);
        void Atualizar(ItemCarrinhoViewModel entidade);
    }
}
