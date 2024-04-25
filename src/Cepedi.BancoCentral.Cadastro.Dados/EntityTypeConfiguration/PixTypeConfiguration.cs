using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepedi.BancoCentral.Cadastro.Dados.EntityTypeConfiguration;

public class PixTypeConfiguration : IEntityTypeConfiguration<PixEntity>
{
    public void Configure(EntityTypeBuilder<PixEntity> builder)
    {
        builder.ToTable("Pix");
        builder.HasKey(c => c.IdPix); // Define a chave primária

        builder.Property(c => c.ChavePix).IsRequired().HasMaxLength(255);
        builder.Property(c => c.TipoPix).IsRequired().HasMaxLength(255);
        builder.Property(c => c.IdPessoa).IsRequired();
    }
}
