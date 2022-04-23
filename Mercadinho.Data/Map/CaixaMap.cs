using Mercearia.Models.VendaContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mercadinho.Data.Map
{
    class CaixaMap : IEntityTypeConfiguration<Caixa>
    {
        public void Configure(EntityTypeBuilder<Caixa> builder)
        {
            builder.ToTable("Caixa");

            builder.HasKey(x => x.Id);

            builder
               .Property(x => x.Id)
               .HasColumnType("INT")
               .ValueGeneratedOnAdd()
               .IsRequired();

            builder
                .Property(x => x.CompraRealizada)
                .HasColumnType("Bit")
                .IsRequired();
        }
    }
}
