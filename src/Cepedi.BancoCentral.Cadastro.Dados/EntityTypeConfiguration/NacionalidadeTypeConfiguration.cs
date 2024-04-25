using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepedi.BancoCentral.Cadastro.Dados.EntityTypeConfiguration;

public class NacionalidadeTypeConfiguration : IEntityTypeConfiguration<NacionalidadeEntity>
{
    public void Configure(EntityTypeBuilder<NacionalidadeEntity> builder)
    {
        builder.ToTable("Nacionalidade");
        builder.HasKey(c => c.IdNacionalidade); // Define a chave primária

        builder.Property(c => c.NomeNacionalidade).IsRequired().HasMaxLength(255);
    }
}
