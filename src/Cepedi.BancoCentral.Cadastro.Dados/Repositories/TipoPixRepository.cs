using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.BancoCentral.Cadastro.Dados.Repositories;

public class TipoPixRepository : ITipoPixRepository
{
    private readonly ApplicationDbContext _context;

    public TipoPixRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TipoPixEntity> CriarTipoPixAsync(TipoPixEntity tipoPix)
    {
        _context.TipoPix.Add(tipoPix);
        await _context.SaveChangesAsync();
        return tipoPix;
    }

    public async Task<TipoPixEntity> AtualizarTipoPixAsync(TipoPixEntity tipoPix)
    {
        _context.TipoPix.Update(tipoPix);
        await _context.SaveChangesAsync();
        return tipoPix;
    }

    public async Task<TipoPixEntity> ObterTipoPixAsync(int id)
    {
        return await _context.TipoPix.Where(p => p.IdTipoPix == id).FirstOrDefaultAsync();
    }

    public async Task<TipoPixEntity> DeletarTipoPixAsync(TipoPixEntity tipoPix) 
    {
        _context.TipoPix.Remove(tipoPix);
        await _context.SaveChangesAsync();
        return tipoPix;
    }

     public async Task<List<TipoPixEntity>> GetTipoPixsAync()
    {
        return await _context.TipoPix.ToListAsync();
    }
}
