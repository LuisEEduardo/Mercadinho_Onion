using AutoMapper;
using Mercadinho.Application.Interface;
using Mercadinho.Application.ViewModel;
using Mercadinho.Domain.Repositories;
using Mercearia.Models.VendaContext;
using System;
using System.Collections.Generic;

namespace Mercadinho.Application.App
{
    public class ProdutoAplicacao : IProdutoAplicacao
    {

        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IMapper _mapper;

        public ProdutoAplicacao(IProdutoRepositorio produtoRepositorio, IMapper mapper)
        {
            _produtoRepositorio = produtoRepositorio;
            _mapper = mapper;
        }

        public void Atualizar(ProdutoViewModel entidade)
        {
            _produtoRepositorio.Atualizar(_mapper.Map<Produto>(entidade));
        }

        public void Excluir(Guid id)
        {
            _produtoRepositorio.Excluir(id);
        }

        public ProdutoViewModel SelecionarPorNome(string nome)
            => _mapper.Map<ProdutoViewModel>(_produtoRepositorio.SelecionarPorNome(nome));

        public void Incluir(ProdutoViewModel entidade)
        {
            _produtoRepositorio.Criar(_mapper.Map<Produto>(entidade));
        }

        public ProdutoViewModel SelecionarPorId(Guid id)
        {
            return _mapper.Map<ProdutoViewModel>(_produtoRepositorio.SelecionarPorId(id));
        }

        public IEnumerable<ProdutoViewModel> SelecionarTodos()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(_produtoRepositorio.SelecionarTodos());
        }
    }
}
