using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepedi.BancoCentral.Cadastro.Dados.EntityTypeConfiguration;

public class EnderecoTypeConfiguration : IEntityTypeConfiguration<EnderecoEntity>
{
    public void Configure(EntityTypeBuilder<EnderecoEntity> builder)
    {
        builder.ToTable("Endereco");
        builder.HasKey(c => c.IdEndereco); // Define a chave primária

        builder.Property(c => c.Cep).IsRequired().HasMaxLength(8);
        builder.Property(c => c.Logradouro).IsRequired().HasMaxLength(255);
        builder.Property(c => c.Numero).IsRequired().HasMaxLength(10);
        builder.Property(c => c.Bairro).IsRequired().HasMaxLength(255);
        builder.Property(c => c.Cidade).IsRequired().HasMaxLength(255);
        builder.Property(c => c.Estado).IsRequired().HasMaxLength(2);
        builder.Property(c => c.Pais).IsRequired().HasMaxLength(255);
        builder.Property(c => c.IdPessoa).IsRequired();
    }
}
