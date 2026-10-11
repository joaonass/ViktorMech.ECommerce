using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Infrastructure.Data.Configurations;
public class ProdutoConfig : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> entity)
    {
        entity.ToTable("Produtos");

        entity.HasKey(p => p.Id);

        entity.ComplexProperty(p => p.NomeDoProduto, nome =>
        {
            nome.Property(n => n.NomeProd)
                .HasColumnName("Nome")
                .HasMaxLength(100)
                .IsRequired();
        });

        entity.ComplexProperty(p => p.Tipo, tipo =>
        {
            tipo.Property(t => t.Tipo)
                .HasColumnName("Tipo")
                .HasMaxLength(100)
                .IsRequired();
        });

        entity.ComplexProperty(p => p.Preco, preco =>
        {
            preco.Property(v => v.Valor)
                .HasColumnName("Preco")
                .HasPrecision(18, 2)
                .IsRequired();
        });

        entity.ComplexProperty(p => p.Estoque, quantidade =>
        {
            quantidade.Property(q => q.Valor)
                .IsRequired();
        });
    }
}