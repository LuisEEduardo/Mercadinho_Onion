using System;

namespace Mercadinho.Application.ViewModel
{
    public class ItemCarrinhoViewModel
    {
        public Guid Id { get; set; }
        public Guid ProdutoId { get; private set; }
        public int Qtd { get; private set; }
    }
}
