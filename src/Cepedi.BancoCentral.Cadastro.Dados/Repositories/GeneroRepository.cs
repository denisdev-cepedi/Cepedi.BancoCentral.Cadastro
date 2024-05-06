using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.BancoCentral.Cadastro.Dados.Repositories;

public class GeneroRepository : IGeneroRepository
{
    private readonly ApplicationDbContext _context;

    public GeneroRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<GeneroEntity> AtualizarGeneroAsync(GeneroEntity genero)
    {
        _context.Genero.Update(genero);

        await _context.SaveChangesAsync();

        return genero;
    }

    public async Task<GeneroEntity> CriarGeneroAsync(GeneroEntity genero)
    {
        _context.Genero.Add(genero);

        await _context.SaveChangesAsync();

        return genero;
    }

    public async Task<GeneroEntity> DeletarGeneroAsync(GeneroEntity genero)
    {
        _context.Genero.Remove(genero);

        await _context.SaveChangesAsync();

        return genero;
    }

    public async Task<List<GeneroEntity>> GetGenerosAsync()
    {
        return await _context.Genero.ToListAsync();
    }

    public async Task<GeneroEntity> ObterGeneroAsync(int id)
    {
        return await
            _context.Genero.Where(e => e.IdGenero == id).FirstOrDefaultAsync();
    }
}
