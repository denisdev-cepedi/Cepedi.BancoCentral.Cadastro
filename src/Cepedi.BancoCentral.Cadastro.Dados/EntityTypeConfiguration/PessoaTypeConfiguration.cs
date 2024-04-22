using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepedi.BancoCentral.Cadastro.Dados.EntityTypeConfiguration;

public class PessoaTypeConfiguration
{
    public void Configure(EntityTypeBuilder<PessoaEntity> builder)
    {
        builder.ToTable("Pessoa");
        builder.HasKey(c => c.IdPessoa); // Define a chave primária

        builder.Property(c => c.Nome).IsRequired().HasMaxLength(150);
        builder.Property(c => c.DataNascimento).IsRequired();
        builder.Property(c => c.Cpf).IsRequired().HasMaxLength(12);
        builder.Property(c => c.Genero).IsRequired();
        builder.Property(c => c.EstadoCivil).IsRequired();
        builder.Property(c => c.Nacionalidade).IsRequired();
    }
}
