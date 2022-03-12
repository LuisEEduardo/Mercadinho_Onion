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
            optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=Mercadinho;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
