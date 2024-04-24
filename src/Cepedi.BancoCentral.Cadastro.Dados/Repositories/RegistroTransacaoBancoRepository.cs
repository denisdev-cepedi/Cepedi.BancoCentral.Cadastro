﻿using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.BancoCentral.Cadastro.Dados.Repositories;
public class RegistroTransacaoBancoRepository : IRegistroTransacaoBancoRepository
{
    private readonly ApplicationDbContext _context;

    public RegistroTransacaoBancoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<RegistroTransacaoBancoEntity> CriarRegistroTransacaoBancoAsync(RegistroTransacaoBancoEntity registroTransacaoBanco)
    {
        await _context.RegistroTransacaoBanco.AddAsync(registroTransacaoBanco);
        await _context.SaveChangesAsync();
        var id = registroTransacaoBanco.IdRegistro;
        return registroTransacaoBanco;
    }

    public async Task<RegistroTransacaoBancoEntity> ObterRegistroTransacaoBancoAsync(int id)
    {
        return await _context.RegistroTransacaoBanco.Include(x => x.TipoRegistro).Include(x => x.Pessoa).Include(x => x.Banco).FirstOrDefaultAsync(x => x.IdRegistro == id);
    }

    public async Task<List<RegistroTransacaoBancoEntity>> ObterRegistroTransacaoBancoAsync()
    {
        return await _context.RegistroTransacaoBanco.Include(x => x.TipoRegistro).Include(x => x.Pessoa).Include(x => x.Banco).ToListAsync();
    }

    public async Task<RegistroTransacaoBancoEntity> AtualizarRegistroTransacaoBancoAsync(RegistroTransacaoBancoEntity registroTransacaoBanco)
    {
        _context.RegistroTransacaoBanco.Update(registroTransacaoBanco);
        await _context.SaveChangesAsync();
        return registroTransacaoBanco;
    }

    public async Task<RegistroTransacaoBancoEntity> DeletarRegistroTransacaoBancoAsync(RegistroTransacaoBancoEntity registroTransacaoBanco)
    {
        _context.RegistroTransacaoBanco.Remove(registroTransacaoBanco);
        await _context.SaveChangesAsync();
        return registroTransacaoBanco;
    }

    public async Task<PessoaEntity> ObterRegistroTransacaoBancoPorIdPessoaAsync(int id)
    {
        return await _context.Pessoa.Where(e => e.IdPessoa == id).FirstOrDefaultAsync();
    }

    public async Task<BancoEntity> ObterRegistroTransacaoBancoPorIdBancoAsync(int id)
    {
        return await _context.Banco.FirstOrDefaultAsync(x => x.IdBanco == id);
    }
}
