using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Catalogo.Domain.AggregationObjects.ProdutoAggregate;

namespace NerdStore.Catalogo.Infrastructure.EntityConfigurations
{
    public class CategoriaEntityTypeConfiguration : BaseEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable(("Categorias"));

            builder.Property(c => c.Nome).IsRequired().HasColumnType("varchar(250)");

            builder.HasMany(c => c.Produtos)
                .WithOne(p => p.Categoria)
                .HasForeignKey(p => p.CategoriaId);
        }
    }
}