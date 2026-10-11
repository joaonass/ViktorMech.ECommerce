
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Infrastructure.Data.Configurations
{
    public class AdministradorConfig : IEntityTypeConfiguration<Administrador>
    {
        public void Configure(EntityTypeBuilder<Administrador> entity)
        {
            entity.ToTable("Adm");

            entity.HasKey(a => a.Id);

            entity.ComplexProperty(a => a.Login, login =>
            {
                login.Property(l => l.Value)
                    .HasColumnName("Login")
                    .IsRequired();
            });
        }
    }
}
