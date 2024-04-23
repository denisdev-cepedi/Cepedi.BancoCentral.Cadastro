using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.BancoCentral.Cadastro.Dados.Repositories;

public class NacionalidadeRepository : INacionalidadeRepository
{
    private readonly ApplicationDbContext _context;

    public NacionalidadeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<NacionalidadeEntity> AtualizarNacionalidadeAsync(NacionalidadeEntity nacionalidade)
    {
        _context.Nacionalidade.Update(nacionalidade);

        await _context.SaveChangesAsync();

        return nacionalidade;
    }

    public async Task<NacionalidadeEntity> CriarNacionalidadeAsync(NacionalidadeEntity nacionalidade)
    {
        _context.Nacionalidade.Add(nacionalidade);

        await _context.SaveChangesAsync();

        return nacionalidade;
    }

    public async Task<NacionalidadeEntity> DeletarNacionalidadeAsync(int id)
    {
        var nacionalidade = await ObterNacionalidadeAsync(id);

        _context.Nacionalidade.Remove(nacionalidade);

        await _context.SaveChangesAsync();

        return nacionalidade;
    }

    public async Task<List<NacionalidadeEntity>> GetNacionalidadesAsync()
    {
        return await _context.Nacionalidade.ToListAsync();
    }

    public async Task<NacionalidadeEntity> ObterNacionalidadeAsync(int id)
    {
        return await
            _context.Nacionalidade.Where(e => e.IdNacionalidade == id).FirstOrDefaultAsync();
    }
}
