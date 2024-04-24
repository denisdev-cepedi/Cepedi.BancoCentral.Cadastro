using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepedi.BancoCentral.Cadastro.Data.EntityTypeConfiguration;

public class BancoEntityTypeConfiguration : IEntityTypeConfiguration<BancoEntity>
{
    public void Configure(EntityTypeBuilder<BancoEntity> builder)
    {
        builder.ToTable("Banco");
        builder.HasKey(c => c.IdBanco);
        builder.Property(banco => banco.NomeFantasia).HasMaxLength(250);
        builder.Property(banco => banco.NomeReal).IsRequired().HasMaxLength(250);
        builder.Property(banco => banco.Cnpj).IsRequired().HasMaxLength(14);
        builder.Property(banco => banco.DataCriacao).IsRequired();
    }
}
