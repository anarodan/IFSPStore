using IFSPStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IFSPStory.Repository.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Nome)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(prop => prop.Preco);

            builder.Property(prop => prop.Quantidade);

            builder.Property(prop => prop.DataCompra);

            builder.Property(prop => prop.UnidadeVenda)
                .HasMaxLength(10);

            builder.HasOne(prop => prop.Grupo)
                .WithMany()
                .HasConstraintName("nome_chave_estrangeira");

        }
    }
}
