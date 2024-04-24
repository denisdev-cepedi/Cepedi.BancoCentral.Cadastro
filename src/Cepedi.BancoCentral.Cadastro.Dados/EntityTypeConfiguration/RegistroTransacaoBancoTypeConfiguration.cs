using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.BancoCentral.Cadastro.Dados.EntityTypeConfiguration;

public class RegistroTransacaoBancoTypeConfiguration : IEntityTypeConfiguration<RegistroTransacaoBancoEntity>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<RegistroTransacaoBancoEntity> builder)
    {
        builder.ToTable("RegistroTransacaoBanco");
        builder.HasKey(c => c.IdRegistro); 

        builder.Property(c => c.DataRegistro).IsRequired();

        builder.HasOne(c => c.TipoRegistro)
            .WithMany()
            .HasForeignKey(c => c.IdTipoRegistro);

        builder.HasOne(c => c.Pessoa)
            .WithMany()
            .HasForeignKey(c => c.IdPessoa);

        builder.HasOne(c => c.Banco)
            .WithMany()
            .HasForeignKey(c => c.IdBanco);

        
    }
}
