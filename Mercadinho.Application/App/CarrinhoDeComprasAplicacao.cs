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

        private readonly ICarrinhoDeComprasRepositorio _carrinhoDeComprasRepositorio;
        private readonly IMapper _mapper;

        public CarrinhoDeComprasAplicacao(ICarrinhoDeComprasRepositorio carrinhoDeComprasRepositorio, IMapper mapper)
        {
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
    }
}
