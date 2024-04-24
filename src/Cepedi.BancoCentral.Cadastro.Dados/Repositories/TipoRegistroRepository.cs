using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.BancoCentral.Cadastro.Data.Repositories;

public class TipoRegistroRepository : ITipoRegistroRepository
{
    private readonly ApplicationDbContext _context;

    public TipoRegistroRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TipoRegistroEntity> AtualizarTipoRegistroAsync(TipoRegistroEntity tipoRegistro)
    {
        _context.TipoRegistro.Update(tipoRegistro);
        await _context.SaveChangesAsync();
        return tipoRegistro;


    }

    public async Task<TipoRegistroEntity> CriarTipoRegistroAsync(TipoRegistroEntity tipoRegistro)
    {
        _context.TipoRegistro.Add(tipoRegistro);

        await _context.SaveChangesAsync();

        return tipoRegistro;
    }

    public async Task<TipoRegistroEntity> DeletarTipoRegistroAsync(TipoRegistroEntity tipoRegistro)
    {
        _context.TipoRegistro.Remove(tipoRegistro);
        await _context.SaveChangesAsync();
        return tipoRegistro;
    }

    public async Task<TipoRegistroEntity> ObterTipoRegistroAsync(int id)
    {
        return (await _context.TipoRegistro.Where(e => e.IdTipoRegistro == id).FirstOrDefaultAsync())!;
    }

    public async Task<List<TipoRegistroEntity>> ObterTipoRegistroAsync()
    {
        return await _context.TipoRegistro.ToListAsync();

    }
}
