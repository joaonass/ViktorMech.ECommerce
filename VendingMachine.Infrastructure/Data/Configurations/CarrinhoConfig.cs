using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Api.Data.Configurations
{
    public class CarrinhoConfig : IEntityTypeConfiguration<Carrinho>
    {
        public void Configure(EntityTypeBuilder<Carrinho> entity)
        {
            entity.ToTable("Carrinho");

            entity.HasKey(c => c.Id);

            entity.HasOne<Usuario>()
                .WithOne()
                .HasForeignKey<Carrinho>(c => c.UsuarioId)
                .IsRequired();

            entity.HasMany(c => c.Itens)
                .WithOne()
                .HasForeignKey(i => i.CarrinhoId)
                .IsRequired();
        }
    }
}