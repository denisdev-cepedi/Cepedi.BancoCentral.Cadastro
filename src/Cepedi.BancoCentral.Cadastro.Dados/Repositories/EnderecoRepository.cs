using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.BancoCentral.Cadastro.Dados.Repositories;

public class EnderecoRepository : IEnderecoRepository
{
    private readonly ApplicationDbContext _context;

    public EnderecoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<EnderecoEntity> AtualizarEnderecoAsync(EnderecoEntity endereco)
    {
        _context.Endereco.Update(endereco);

        return endereco;
    }

    public async Task<EnderecoEntity> CriarEnderecoAsync(EnderecoEntity endereco)
    {
        _context.Endereco.Add(endereco);

        return endereco;
    }

    public async Task<EnderecoEntity> DeletarEnderecoAsync(EnderecoEntity endereco)
    {
        _context.Endereco.Remove(endereco);

        return endereco;
    }

    public async Task<List<EnderecoEntity>> GetEnderecosAsync()
    {
        return await _context.Endereco.ToListAsync();
    }

    public async Task<EnderecoEntity> ObterEnderecoAsync(int id)
    {
        return await
            _context.Endereco.Where(e => e.IdEndereco == id).FirstOrDefaultAsync();
    }
}
