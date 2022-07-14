using AutoMapper;
using Mercadinho.Application.Interface;
using Mercadinho.Application.ViewModel;
using Mercadinho.Domain.Models.VendaContext;
using Mercadinho.Domain.Repositories;
using System.Collections.Generic;

namespace Mercadinho.Application.App
{
    public class PedidoAplicacao : IPedidoAplicacao
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;
        private readonly IMapper _mapper;

        public PedidoAplicacao(IPedidoRepositorio pedidoRepositorio, IMapper mapper)
        {
            _pedidoRepositorio = pedidoRepositorio;
            _mapper = mapper;
        }

        public void Atualizar(PedidoViewModel entidade)
        {
            _pedidoRepositorio.Atualizar(_mapper.Map<Pedido>(entidade));
        }

        public void Excluir(int id)
        {
            _pedidoRepositorio.Excluir(id);
        }

        public void Incluir(PedidoViewModel entidade)
        {
            _pedidoRepositorio.Criar(_mapper.Map<Pedido>(entidade));
        }

        public PedidoViewModel SelecionarPorId(int id)
        {
            return _mapper.Map<PedidoViewModel>(_pedidoRepositorio.SelecionarPorId(id));
        }

        public IEnumerable<PedidoViewModel> SelecionarTodos()
        {
            return _mapper.Map<IEnumerable<PedidoViewModel>>(_pedidoRepositorio.SelecionarTodos());
        }
    }
}
