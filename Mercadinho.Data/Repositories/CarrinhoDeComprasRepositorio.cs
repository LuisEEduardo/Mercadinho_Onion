﻿using Mercadinho.Domain.Repositories;
using Mercearia.Models.VendaContext;

namespace Mercadinho.Data.Repositories
{
    internal class CarrinhoDeComprasRepositorio : BaseRepositorio<CarrinhoDeCompras>, ICarrinhoDeComprasRepositorio
    {
        public CarrinhoDeComprasRepositorio(Contexto contexto) 
            : base(contexto)
        {
        }
    }
}
