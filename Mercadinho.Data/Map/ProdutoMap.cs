using Mercearia.Models.VendaContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mercadinho.Data.Map
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired();

            builder
                .Property(x => x.Nome)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            builder
                .Property(x => x.Preco)
                .HasColumnType("Decimal")
                .IsRequired();

            builder
                .Property(x => x.Descricao)
                .HasColumnType("VARCHAR(300)")
                .IsRequired();
        }
    }
}
