using System.Diagnostics.CodeAnalysis;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.BancoCentral.Cadastro.Data;

[ExcludeFromCodeCoverage]
public class ApplicationDbContext : DbContext
{
    public DbSet<UsuarioEntity> Usuario { get; set; } = default!;
    public DbSet<TipoRegistroEntity> TipoRegistro {get; set;} = default!;
    public DbSet<BancoEntity> Banco { get; set; } = default!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
