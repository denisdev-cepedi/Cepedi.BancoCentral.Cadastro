using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.BancoCentral.Cadastro.Data.Repositories;

public class BancoRepository : IBancoRepository
{
    private readonly ApplicationDbContext _context;
    
    public BancoRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<BancoEntity> CriarBancoAsync(BancoEntity banco)
    {
        _context.Banco.Add(banco);
        await _context.SaveChangesAsync();
        return banco;
    }

    public async Task<BancoEntity> ObterBancoAsync(int id)
    {
        return (await _context.Banco.Where(banco => banco.IdBanco == id).FirstOrDefaultAsync())!;
    }

    public async Task<List<BancoEntity>> ObterBancoAsync()
    {
        return await _context.Banco.ToListAsync();
    }

    public async Task<BancoEntity> AtualizarBancoAsync(BancoEntity banco)
    {
        _context.Banco.Update(banco);
        await _context.SaveChangesAsync();
        return banco;
    }

    public async Task<BancoEntity> DeletarBancoAsync(BancoEntity banco)
    {
        _context.Banco.Remove(banco);
        await _context.SaveChangesAsync();
        return banco;
    }
}
