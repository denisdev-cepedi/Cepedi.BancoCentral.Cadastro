﻿using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepedi.BancoCentral.Cadastro.Data.EntityTypeConfiguration;

public class TipoRegistroEntityTypeConfiguration : IEntityTypeConfiguration<TipoRegistroEntity>
{
    public void Configure(EntityTypeBuilder<TipoRegistroEntity> builder)
    {
        builder.ToTable("TipoRegistro");
        builder.HasKey(c => c.IdTipoRegistro);
        builder.Property(c => c.NomeTipo).IsRequired().HasMaxLength(250);
    }
}
