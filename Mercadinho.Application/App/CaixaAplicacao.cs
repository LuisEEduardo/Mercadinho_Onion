using AutoMapper;
using Mercadinho.Application.Interface;
using Mercadinho.Application.ViewModel;
using Mercadinho.Domain.Repositories;
using Mercearia.Models.VendaContext;
using System.Collections.Generic;

namespace Mercadinho.Application.App
{
    public class CaixaAplicacao : ICaixaAplicacao
    {
        private readonly ICaixaRepositorio _caixaRepositorio;
        private readonly IMapper _mapper;

        public CaixaAplicacao(ICaixaRepositorio caixaRepositorio, IMapper mapper)
        {
            _caixaRepositorio = caixaRepositorio;
            _mapper = mapper;
        }

        public void Atualizar(CaixaViewModel entidade)
        {
            _caixaRepositorio.Atualizar(_mapper.Map<Caixa>(entidade));
        }

        public void Excluir(int id)
        {
            _caixaRepositorio.Excluir(id);
        }

        public void Incluir(CaixaViewModel entidade)
        {
            _caixaRepositorio.Criar(_mapper.Map<Caixa>(entidade));
        }

        public CaixaViewModel SelecionarPorId(int id)
        {
            return _mapper.Map<CaixaViewModel>(_caixaRepositorio.SelecionarPorId(id));
        }

        public IEnumerable<CaixaViewModel> SelecionarTodos()
        {
            return _mapper.Map<IEnumerable<CaixaViewModel>>(_caixaRepositorio.SelecionarTodos());
        }
    }
}