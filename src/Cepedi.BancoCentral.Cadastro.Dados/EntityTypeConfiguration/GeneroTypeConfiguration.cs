using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepedi.BancoCentral.Cadastro.Dados.EntityTypeConfiguration;

public class GeneroTypeConfiguration : IEntityTypeConfiguration<GeneroEntity>
{
    public void Configure(EntityTypeBuilder<GeneroEntity> builder)
    {
        builder.ToTable("Genero");
        builder.HasKey(c => c.IdGenero); // Define a chave primária

        builder.Property(c => c.NomeGenero).IsRequired().HasMaxLength(255);
    }
}
