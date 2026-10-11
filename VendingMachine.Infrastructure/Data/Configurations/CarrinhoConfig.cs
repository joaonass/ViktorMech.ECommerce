using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Infrastructure.Data.Configurations
{
    public class CarrinhoConfig : IEntityTypeConfiguration<Carrinho>
    {
        public void Configure(EntityTypeBuilder<Carrinho> entity)
        {
            entity.ToTable("Carrinho");

            entity.HasKey(c => c.Id);

            entity.HasOne<Usuario>()
                .WithMany()
                .HasForeignKey(c => c.UsuarioId)
                .IsRequired(false);

            entity.HasMany(c => c.Itens)
                .WithOne()
                .HasForeignKey(i => i.CarrinhoId)
                .IsRequired();
        }
    }
}