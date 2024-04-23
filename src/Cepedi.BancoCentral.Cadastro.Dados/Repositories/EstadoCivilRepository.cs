using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.BancoCentral.Cadastro.Dados.Repositories;

public class EstadoCivilRepository
{
    private readonly ApplicationDbContext _context;

    public EstadoCivilRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<EstadoCivilEntity> AtualizarEstadoCivilAsync(EstadoCivilEntity estadoCivil)
    {
        _context.EstadoCivil.Update(estadoCivil);

        await _context.SaveChangesAsync();

        return estadoCivil;
    }

    public async Task<EstadoCivilEntity> CriarEstadoCivilAsync(EstadoCivilEntity estadoCivil)
    {
        _context.EstadoCivil.Add(estadoCivil);

        await _context.SaveChangesAsync();

        return estadoCivil;
    }

    public async Task<EstadoCivilEntity> DeletarEstadoCivilAsync(int id)
    {
        var estadoCivil = await ObterEstadoCivilAsync(id);

        _context.EstadoCivil.Remove(estadoCivil);

        await _context.SaveChangesAsync();

        return estadoCivil;
    }

    public async Task<List<EstadoCivilEntity>> GetEstadoCivilAsync()
    {
        return await _context.EstadoCivil.ToListAsync();
    }

    public async Task<EstadoCivilEntity> ObterEstadoCivilAsync(int id)
    {
        return await
            _context.EstadoCivil.Where(e => e.IdEstadoCivil == id).FirstOrDefaultAsync();
    }    
}
