using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepedi.BancoCentral.Cadastro.Dados.EntityTypeConfiguration;

public class EstadoCivilTypeConfiguration
{
    public void Configure(EntityTypeBuilder<EstadoCivilEntity> builder)
    {
        builder.ToTable("EstadoCivil");
        builder.HasKey(c => c.IdEstadoCivil); // Define a chave primária

        builder.Property(c => c.NomeEstadoCivil).IsRequired().HasMaxLength(255);
    }
}
