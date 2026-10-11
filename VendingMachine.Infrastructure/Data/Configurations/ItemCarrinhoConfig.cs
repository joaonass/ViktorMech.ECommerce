using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Infrastructure.Data.Configurations
{
    public class ItemCarrinhoConfig : IEntityTypeConfiguration<ItemCarrinho>
    {
        public void Configure(EntityTypeBuilder<ItemCarrinho> entity)
        {
            entity.ToTable("ItensCarrinho");

            entity.HasKey(i => i.Id);

            entity.HasOne<Produto>()
                .WithMany()
                .HasForeignKey(i => i.ProdutoId)
                .IsRequired();


            entity.ComplexProperty(i => i.Quantidade, quantidade =>
            {
                quantidade.Property(q => q.Valor)
                    .HasColumnName("Quantidade")
                    .IsRequired();
            });
        }
    }
}
