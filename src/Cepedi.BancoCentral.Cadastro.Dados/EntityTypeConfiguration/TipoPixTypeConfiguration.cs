using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepedi.BancoCentral.Cadastro.Dados.EntityTypeConfiguration;

public class TipoPixEntityTypeConfiguration
{
    public void Configure(EntityTypeBuilder<TipoPixEntity> builder)
    {
        builder.ToTable("TipoPix"); // Define o nome da tabela no banco de dados

        builder.HasKey(t => t.IdTipoPix); // Define a chave primária

        // Mapeamento das propriedades
        builder.Property(t => t.IdTipoPix).IsRequired();
        builder.Property(t => t.TipoPix).IsRequired().HasMaxLength(255);

        // Mapeamento do relacionamento com a entidade PixEntity
    /*     builder.HasMany(t => t.Pixs)
               .WithOne(p => p.IdPix)
               .HasForeignKey(p => p.IdTipoPix)
               .IsRequired(false);  */
    }
}
