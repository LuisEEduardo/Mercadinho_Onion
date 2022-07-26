using Mercadinho.Application.ViewModel;
using System.Collections.Generic;

namespace Mercadinho.Application.Interface
{
    public interface ICarrinhoDeComprasAplicacao
    {
        void Incluir(CarrinhoDeComprasViewModel entidade);
        IEnumerable<CarrinhoDeComprasViewModel> SelecionarTodos();
        CarrinhoDeComprasViewModel SelecionarPorId(int id);
        void Excluir(int id);
        void Atualizar(CarrinhoDeComprasViewModel entidade);
        void IncluirItem(ItemCarrinhoViewModel entidade);
        IEnumerable<ItemCarrinhoViewModel> SelecionarTodosItens();
        ItemCarrinhoViewModel SelecionarPorIdItem(int id);
        void ExcluirItem(int id);
        void AtualizarItem(ItemCarrinhoViewModel entidade);
    }
}
