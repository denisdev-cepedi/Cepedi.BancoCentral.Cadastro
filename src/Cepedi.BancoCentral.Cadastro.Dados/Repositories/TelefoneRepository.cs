using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.BancoCentral.Cadastro.Dados.Repositories;

public class TelefoneRepository : ITelefoneRepository
{
    private readonly ApplicationDbContext _context;

    public TelefoneRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TelefoneEntity> AtualizarTelefoneAsync(TelefoneEntity telefone)
    {
        _context.Telefone.Update(telefone);
        
        return telefone;
    }

    public async Task<TelefoneEntity> CriarTelefoneAsync(TelefoneEntity telefone)
    {
        _context.Telefone.Add(telefone);

        return telefone;
    }

    public async Task<TelefoneEntity> DeletarTelefoneAsync(TelefoneEntity telefone)
    {
        _context.Telefone.Remove(telefone);

        return telefone;
    }

    public async Task<List<TelefoneEntity>> GetTelefonesAsync()
    {
        return await _context.Telefone.ToListAsync();
    }

    public async Task<TelefoneEntity> ObterTelefoneAsync(int id)
    {
        return await
            _context.Telefone.Where(e => e.IdTelefone == id).FirstOrDefaultAsync();
    }
}
