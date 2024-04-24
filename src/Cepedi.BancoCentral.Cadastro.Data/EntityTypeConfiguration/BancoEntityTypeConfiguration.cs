using Cepedi.BancoCentral.Cadastro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepedi.BancoCentral.Cadastro.Data.EntityTypeConfiguration;

public class BancoEntityTypeConfiguration : IEntityTypeConfiguration<BancoEntity>
{
    public void Configure(EntityTypeBuilder<BancoEntity> builder)
    {
        builder.ToTable("Bancos");
        builder.HasKey(b => b.IdBanco);

        builder.Property(b => b.NomeFantasia).IsRequired().HasMaxLength(255);
        builder.Property(b => b.NomeReal).IsRequired().HasMaxLength(255);
        builder.Property(b => b.Cnpj).IsRequired().HasMaxLength(14);
        builder.Property(b => b.DataCriacao).IsRequired();
    }
}
