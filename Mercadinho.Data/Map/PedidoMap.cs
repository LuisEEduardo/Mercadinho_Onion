using Mercadinho.Domain.Models.VendaContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mercadinho.Data.Map
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");

            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnType("INT")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder
                .Property(x => x.DataDaCompra)
                .HasColumnType("DateTime")
                .IsRequired();

            builder
                .Property(x => x.ValorTotal)
                .HasColumnType("Decimal")
                .IsRequired();

            builder
                .Property(x => x.FormaPagamento)
                .HasColumnType("INT")
                .IsRequired();

            builder
                .Property(x => x.PagamentoConfirmado)
                .HasColumnType("BIT")
                .IsRequired();

            builder
                .HasOne(x => x.CarrinhoDeCompras)
                .WithOne(x => x.Pedido)
                .HasForeignKey<Pedido>(x => x.CarrinhoId);
        }
    }
}
