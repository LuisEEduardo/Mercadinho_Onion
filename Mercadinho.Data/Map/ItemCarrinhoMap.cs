using Mercearia.Models.VendaContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Mercadinho.Data.Map
{
    class ItemCarrinhoMap : IEntityTypeConfiguration<ItemCarrinho>
    {
        public void Configure(EntityTypeBuilder<ItemCarrinho> builder)
        {
            builder.ToTable("ItemCarrinho");

            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired();

            builder
                .Property(x => x.Qtd)
                .HasColumnType("INT")
                .IsRequired();

            builder
                .HasOne(x => x.Produto)
                .WithMany(x => x.ItensCarrinho)
                .HasForeignKey(x => x.ProdutoId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
