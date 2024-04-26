using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepedi.BancoCentral.Cadastro.Dados.EntityTypeConfiguration;

public class BancoEntityTypeConfiguration : IEntityTypeConfiguration<BancoEntity>
{
    public void Configure(EntityTypeBuilder<BancoEntity> builder)
    {
        builder.ToTable("Banco");
        builder.HasKey(c => c.IdBanco);
    }
}
