using AutoMapper;
using Mercadinho.Application.Interface;
using Mercadinho.Application.ViewModel;
using Mercadinho.Domain.Repositories;
using Mercearia.Models.VendaContext;
using System.Collections.Generic;

namespace Mercadinho.Application.App
{
    public class CarrinhoDeComprasAplicacao : ICarrinhoDeComprasAplicacao
    {
        private readonly IItemCarrinhoRepositorio _itemCarrinhoRepositorio;
        private readonly ICarrinhoDeComprasRepositorio _carrinhoDeComprasRepositorio;
        private readonly IMapper _mapper;

        public CarrinhoDeComprasAplicacao(IItemCarrinhoRepositorio itemCarrinhoRepositorio, ICarrinhoDeComprasRepositorio carrinhoDeComprasRepositorio, IMapper mapper)
        {
            _itemCarrinhoRepositorio = itemCarrinhoRepositorio;
            _carrinhoDeComprasRepositorio = carrinhoDeComprasRepositorio;
            _mapper = mapper;
        }

        public void Atualizar(CarrinhoDeComprasViewModel entidade)
        {
            _carrinhoDeComprasRepositorio.Atualizar(_mapper.Map<CarrinhoDeCompras>(entidade));
        }

        public void Excluir(int id)
        {
            _carrinhoDeComprasRepositorio.Excluir(id);
        }

        public void Incluir(CarrinhoDeComprasViewModel entidade)
        {
            _carrinhoDeComprasRepositorio.Criar(_mapper.Map<CarrinhoDeCompras>(entidade));
        }

        public CarrinhoDeComprasViewModel SelecionarPorId(int id)
        {
            return _mapper.Map<CarrinhoDeComprasViewModel>(_carrinhoDeComprasRepositorio.SelecionarPorId(id));
        }

        public IEnumerable<CarrinhoDeComprasViewModel> SelecionarTodos()
        {
            return _mapper.Map<IEnumerable<CarrinhoDeComprasViewModel>>(_carrinhoDeComprasRepositorio.SelecionarTodos());
        }


        public void AtualizarItem(ItemCarrinhoViewModel entidade)
        {
            _itemCarrinhoRepositorio.Atualizar(_mapper.Map<ItemCarrinho>(entidade));
        }

        public void ExcluirItem(int id)
        {
            _itemCarrinhoRepositorio.Excluir(id);
        }

        public void IncluirItem(ItemCarrinhoViewModel entidade)
        {
            _itemCarrinhoRepositorio.Criar(_mapper.Map<ItemCarrinho>(entidade));
        }

        public ItemCarrinhoViewModel SelecionarPorIdItem(int id)
        {
            return _mapper.Map<ItemCarrinhoViewModel>(_itemCarrinhoRepositorio.SelecionarPorId(id));
        }

        public IEnumerable<ItemCarrinhoViewModel> SelecionarTodosItens()
        {
            return _mapper.Map<IEnumerable<ItemCarrinhoViewModel>>(_itemCarrinhoRepositorio.SelecionarTodos());
        }

    }
}
