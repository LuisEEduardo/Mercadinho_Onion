using Mercadinho.Application.ViewModel;
using System;
using System.Collections.Generic;

namespace Mercadinho.Application.Interface
{
    public interface IProdutoAplicacao
    {
        void Incluir(ProdutoViewModel entidade);
        IEnumerable<ProdutoViewModel> SelecionarTodos();
        ProdutoViewModel SelecionarPorId(int id);
        ProdutoViewModel SelecionarPorNome(string nome);
        void Excluir(int id);
        void Atualizar(ProdutoViewModel entidade);  
    }
}
