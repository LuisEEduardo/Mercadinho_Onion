using Mercadinho.Data.Map;
using Mercearia.Models.VendaContext;
using Microsoft.EntityFrameworkCore;

namespace Mercadinho.Data
{
    public class Contexto : DbContext
    {
        DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=MIR-0553\SQLEXPRESS;Database=Mercadinho;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
