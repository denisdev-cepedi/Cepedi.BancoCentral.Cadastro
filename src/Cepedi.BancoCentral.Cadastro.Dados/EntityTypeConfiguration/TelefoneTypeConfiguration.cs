using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepedi.BancoCentral.Cadastro.Dados.EntityTypeConfiguration;

public class TelefoneTypeConfiguration
{   
    public void Configure(EntityTypeBuilder<TelefoneEntity> builder)
    {
        builder.ToTable("Telefone");
        builder.HasKey(c => c.IdTelefone); // Define a chave primária

        builder.Property(c => c.NumeroTelefone).IsRequired().HasMaxLength(15);
        builder.Property(c => c.IdPessoa).IsRequired();
    }
}
