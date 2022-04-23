using Mercadinho.Data.Map;
using Mercearia.Models.VendaContext;
using Microsoft.EntityFrameworkCore;

namespace Mercadinho.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        {
        }

        DbSet<Produto> Produtos { get; set; }      
        DbSet<ItemCarrinho> ItemCarrinhos { get; set; }
        DbSet<CarrinhoDeCompras> CarrinhoDeCompras { get; set; }
        DbSet<Caixa> Caixas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new ItemCarrinhoMap());
            modelBuilder.ApplyConfiguration(new CarrinhoDeComprasMap());
            modelBuilder.ApplyConfiguration(new CaixaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
