using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Dominio.Services;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.BancoCentral.Cadastro.Dados.Repositories;

public class PessoaRepository : IPessoaRepository
{
    private readonly ApplicationDbContext _context;
    private readonly ICache<List<PessoaEntity>> _cache;

    public PessoaRepository(ApplicationDbContext context, ICache<List<PessoaEntity>> cache)
    {
        _context = context;
        _cache = cache;
    }

    public async Task<PessoaEntity> AtualizarPessoaAsync(PessoaEntity pessoa)
    {
        _context.Pessoa.Update(pessoa);

        await _context.SaveChangesAsync();

        return pessoa;
    }

    public async Task<PessoaEntity> CriarPessoaAsync(PessoaEntity pessoa)
    {
        _context.Pessoa.Add(pessoa);

        await _context.SaveChangesAsync();

        return pessoa;
    }

    public async Task<List<PessoaEntity>> GetPessoasAsync()
    {
        var pessoas = await _cache.ObterAsync("Pessoas");

        if (pessoas == null)
        {
            pessoas = await _context.Pessoa.ToListAsync();
            await _cache.SalvarAsync("Pessoas", pessoas, 60); // 60 segundos de tempo de expiração
        }

        return pessoas;
    }

    public async Task<PessoaEntity> ObterPessoaAsync(int id)
    {
        return await
            _context.Pessoa.Where(e => e.IdPessoa == id).FirstOrDefaultAsync();
    }

    public async Task<PessoaEntity> DeletarPessoaAsync(PessoaEntity pessoa)
    {
        _context.Pessoa.Remove(pessoa);

        await _context.SaveChangesAsync();

        return pessoa;
    }
}
