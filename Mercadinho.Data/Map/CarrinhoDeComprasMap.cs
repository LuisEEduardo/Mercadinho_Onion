using Mercearia.Models.VendaContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mercadinho.Data.Map
{
    class CarrinhoDeComprasMap : IEntityTypeConfiguration<CarrinhoDeCompras>
    {
        public void Configure(EntityTypeBuilder<CarrinhoDeCompras> builder)
        {
            builder.ToTable("CarrinhoDeCompras");

            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnType("INT")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder
                .Property(x => x.ValorTotalCarrinho)
                .HasColumnType("Decimal");

            builder
                .Property(x => x.StatusDaCompra)
                .HasColumnType("INT")
                .IsRequired();  

            builder
                .HasMany(x => x.Itens)
                .WithOne(x => x.CarrinhoDeCompras)
                .HasForeignKey(x => x.CarrinhoDeComprasId);
        }
    }
}
