using System.Diagnostics.CodeAnalysis;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.BancoCentral.Cadastro.Dados;

[ExcludeFromCodeCoverage]
public class ApplicationDbContext : DbContext
{
    public DbSet<EmailEntity> Email { get; set; } = default!;
    public DbSet<EnderecoEntity> Endereco { get; set; } = default!;
    public DbSet<EstadoCivilEntity> EstadoCivil { get; set; } = default!;
    public DbSet<GeneroEntity> Genero { get; set; } = default!;
    public DbSet<NacionalidadeEntity> Nacionalidade { get; set; } = default!;
    public DbSet<PessoaEntity> Pessoa { get; set; } = default!;
    public DbSet<TelefoneEntity> Telefone { get; set; } = default!;
    public DbSet<PixEntity> Pix { get; set; } = default!;
    public DbSet<UsuarioEntity> Usuario { get; set; } = default!;
    public DbSet<TipoRegistroEntity> TipoRegistro {get; set;} = default!;
    public DbSet<PessoaEntity> Pessoa {get; set;} = default!;
    public DbSet<BancoEntity> Banco {get; set;} = default!;
    public DbSet<RegistroTransacaoBancoEntity> RegistroTransacaoBanco {get; set;} = default!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
