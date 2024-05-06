using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.BancoCentral.Cadastro.Dados.Repositories;

public class PixRepository : IPixRepository
{
    private readonly ApplicationDbContext _context;

    public PixRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PixEntity> AtualizarPixAsync(PixEntity pix)
    {
        _context.Pix.Update(pix);

        await _context.SaveChangesAsync();

        return pix;
    }

    public async Task<PixEntity> CriarPixAsync(PixEntity pix)
    {
        _context.Pix.Add(pix);

        await _context.SaveChangesAsync();

        return pix;
    }

    public async Task<PixEntity> DeletarPixAsync(PixEntity pix)
    {
        _context.Pix.Remove(pix);

        await _context.SaveChangesAsync();

        return pix;
    }

    public async Task<List<PixEntity>> GetPixsAsync()
    {
        return await _context.Pix.ToListAsync();
    }

    public async Task<PixEntity> ObterPixAsync(int id)
    {
        return await
            _context.Pix.Where(e => e.IdPix == id).FirstOrDefaultAsync();
    }
}
