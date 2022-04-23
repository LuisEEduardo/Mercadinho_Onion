using AutoMapper;
using Mercadinho.Application.ViewModel;
using Mercearia.Models.VendaContext;

namespace Mercadinho.Application.Mapper
{
    public class AutoMapperConfig : Profile
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(x => x.AllowNullCollections = true);
        }

        public AutoMapperConfig()
        {
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
            CreateMap<ItemCarrinho, ItemCarrinhoViewModel>().ReverseMap();
            CreateMap<CarrinhoDeCompras, CarrinhoDeComprasViewModel>().ReverseMap();
            CreateMap<Caixa, CaixaViewModel>().ReverseMap();
        }
    }
}
