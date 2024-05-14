using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.BancoCentral.Cadastro.Dados.EntityTypeConfiguration;

public class PessoaEntityTypeConfiguration : IEntityTypeConfiguration<PessoaEntity>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PessoaEntity> builder)
    {
        builder.ToTable("Pessoa");
        builder.HasKey(c => c.IdPessoa);
    }
}
