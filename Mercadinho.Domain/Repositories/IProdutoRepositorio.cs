﻿using Mercearia.Models.VendaContext;

namespace Mercadinho.Domain.Repositories
{
    public interface IProdutoRepositorio : IBaseRespositorio<Produto>
    {
        Produto SelecionarPorNome(string nome);
    }
}
