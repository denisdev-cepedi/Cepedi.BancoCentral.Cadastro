using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepedi.BancoCentral.Cadastro.Dados.EntityTypeConfiguration;

public class EmailTypeConfiguration
{
    public void Configure(EntityTypeBuilder<EmailEntity> builder)
    {
        builder.ToTable("Email");
        builder.HasKey(c => c.IdEmail); // Define a chave primária

        builder.Property(c => c.EnderecoEmail).IsRequired().HasMaxLength(255);
        builder.Property(c => c.IdPessoa).IsRequired();
    }
}
