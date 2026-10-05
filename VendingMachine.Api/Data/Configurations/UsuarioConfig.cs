using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Api.Data.Configurations
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> entity)
        {
            entity.ToTable("Usuarios");

            entity.HasKey(u => u.Id);

            entity.ComplexProperty(u => u.NomeCompleto, nome =>
            {
                nome.Property(n => n.Nome)
                    .HasColumnName("Nome")
                    .HasMaxLength(100)
                    .IsRequired();
            });

            entity.ComplexProperty(u => u.Cpf, cpf =>
            {
                cpf.Property(c => c.Valor)
                .HasColumnName("Cpf")
                .HasMaxLength(11)
                .IsRequired();
                
            });

            entity.ComplexProperty(u => u.Email, email =>
            {
                email.Property(e => e.Endereco)
                .HasColumnName("Email")
                .IsRequired();
            });

            entity.ComplexProperty(u => u.Telefone, telefone =>
            {
                telefone.Property(t => t.Tel)
                .HasColumnName("Telefone")
                .HasMaxLength(11)
                .IsRequired();
            });

            entity.ComplexProperty(u => u.Endereco, endereco =>
            {
                endereco.Property(e => e.Rua)
                    .HasColumnName("Rua")
                    .HasMaxLength(150)
                    .IsRequired();

                endereco.Property(e => e.NumeroDoImovel)
                    .HasColumnName("NumeroDoImovel")
                    .IsRequired();

                endereco.Property(e => e.Bairro)
                    .HasColumnName("Bairro")
                    .HasMaxLength(100)
                    .IsRequired();

                endereco.Property(e => e.Cidade)
                    .HasColumnName("Cidade")
                    .HasMaxLength(100)
                    .IsRequired();

                endereco.Property(e => e.Cep)
                    .HasColumnName("Cep")
                    .HasMaxLength(8)
                    .IsRequired();
            });
        }
    }
}
