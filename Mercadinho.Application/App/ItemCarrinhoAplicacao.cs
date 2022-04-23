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
            _itemCarrinhoRepositorio.Atualizar(_mapper.Map<ItemCarrinho>(entidade));
        }

        public void Excluir(int id)
        {
            _itemCarrinhoRepositorio.Excluir(id);
        }

        public void Incluir(ItemCarrinhoViewModel entidade)
        {
            _itemCarrinhoRepositorio.Criar(_mapper.Map<ItemCarrinho>(entidade));
        }

        public ItemCarrinhoViewModel SelecionarPorId(int id)
        {
            return _mapper.Map<ItemCarrinhoViewModel>(_itemCarrinhoRepositorio.SelecionarPorId(id));
        }

        public IEnumerable<ItemCarrinhoViewModel> SelecionarTodos()
        {
            return _mapper.Map<IEnumerable<ItemCarrinhoViewModel>>(_itemCarrinhoRepositorio.SelecionarTodos());
        }
    }
}
