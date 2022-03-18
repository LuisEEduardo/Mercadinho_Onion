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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
