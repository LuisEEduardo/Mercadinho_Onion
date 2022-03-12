using AutoMapper;
using Mercadinho.Application.Interface;
using Mercadinho.Application.ViewModel;
using Mercadinho.Domain.Repositories;
using Mercearia.Models.VendaContext;

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

        public void Incluir(ProdutoViewModel entidade)
        {
            _produtoRepositorio.Criar(_mapper.Map<Produto>(entidade));
        }
    }
}
