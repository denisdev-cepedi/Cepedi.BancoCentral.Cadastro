using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepedi.BancoCentral.Cadastro.Dados.EntityTypeConfiguration;

public class PixEntityTypeConfiguration
{
    public void Configure(EntityTypeBuilder<PixEntity> builder)
    {
        builder.ToTable("Pix"); // Nome da tabela no banco de dados

        builder.HasKey(p => p.IdPix); // Define a chave primária

        // Mapeamento das propriedades
        builder.Property(p => p.IdPix).IsRequired();
        builder.Property(p => p.ChavePix).IsRequired();
        builder.Property(p => p.Agencia).IsRequired();
        builder.Property(p => p.Conta).IsRequired();
        builder.Property(p => p.Instituicao).IsRequired();
        builder.Property(p => p.IdTipoPix).IsRequired();

        // Relacionamento com a entidade TipoPix
        builder.HasOne(p => p.TipoPixEntity)
               .WithMany()
               .HasForeignKey(p => p.IdTipoPix);
    }
}
