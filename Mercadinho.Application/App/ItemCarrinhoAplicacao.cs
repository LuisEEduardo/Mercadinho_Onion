using AutoMapper;
using Mercadinho.Application.Interface;
using Mercadinho.Application.ViewModel;
using Mercadinho.Domain.Repositories;
using Mercearia.Models.VendaContext;
using System;
using System.Collections.Generic;

namespace Mercadinho.Application.App
{
    public class ItemCarrinhoAplicacao : IItemCarrinhoAplicacao
    {
        private readonly IItemCarrinhoRepositorio _itemCarrinhoRepositorio;
        private readonly IMapper _mapper;

        public ItemCarrinhoAplicacao(IItemCarrinhoRepositorio itemCarrinhoRepositorio, IMapper mapper)
        {
            _itemCarrinhoRepositorio = itemCarrinhoRepositorio;
            _mapper = mapper;
        }

        public void Atualizar(ItemCarrinhoViewModel entidade)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Incluir(ItemCarrinhoViewModel entidade)
        {
            _itemCarrinhoRepositorio.Criar(_mapper.Map<ItemCarrinho>(entidade));
        }

        public ItemCarrinhoViewModel SelecionarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemCarrinhoViewModel> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
