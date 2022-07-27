using Mercadinho.Data.Map;
using Mercadinho.Domain.Models.VendaContext;
using Mercearia.Models.VendaContext;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mercadinho.Data
{
    public class Contexto : IdentityDbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        {
        }

        DbSet<Produto> Produtos { get; set; }      
        DbSet<ItemCarrinho> ItemCarrinhos { get; set; }
        DbSet<CarrinhoDeCompras> CarrinhoDeCompras { get; set; }
        DbSet<Pedido> Pedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new ItemCarrinhoMap());
            modelBuilder.ApplyConfiguration(new CarrinhoDeComprasMap());
            modelBuilder.ApplyConfiguration(new PedidoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
