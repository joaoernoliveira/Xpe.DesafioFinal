
using Microsoft.EntityFrameworkCore;
using Xpe.DesafioFinal.Domain.Entities;

namespace Arquitetura.Teste.EntityDDD.Infra.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            // Cliente
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(d => d.Nome).HasColumnName("Nome").HasColumnType("string").IsRequired().HasMaxLength(100);
            builder.Property(d => d.Cpf).HasColumnName("Cpf").HasColumnType("string").IsRequired().HasMaxLength(11);
            builder.Property(d => d.DataNascimento).HasColumnName("DataNascimento").HasColumnType("DateTime").IsRequired();

            // Contatos
            builder.OwnsOne(x => x.Contatos).Property(x => x.Email).HasColumnName("Email").IsRequired(true).HasMaxLength(80);
            builder.OwnsOne(x => x.Contatos).Property(x => x.Celular).HasColumnName("Celular").IsRequired(true).HasMaxLength(15);

            // Endereço 
            builder.OwnsOne(x => x.Endereco).Property(x => x.Cep).HasColumnName("Cep").IsRequired(true).HasMaxLength(8);
            builder.OwnsOne(x => x.Endereco).Property(x => x.LogradouroTipo).HasColumnName("LogradouroTipo").IsRequired(true).HasMaxLength(30);
            builder.OwnsOne(x => x.Endereco).Property(x => x.Logradouro).HasColumnName("Logradouro").IsRequired(true).HasMaxLength(80);
            builder.OwnsOne(x => x.Endereco).Property(x => x.Numero).HasColumnName("Numero").IsRequired(true).HasMaxLength(10);
            builder.OwnsOne(x => x.Endereco).Property(x => x.Complemento).HasColumnName("Complemento").IsRequired(true).HasMaxLength(80);
        }
    }
}