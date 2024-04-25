﻿using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.BancoCentral.Cadastro.Dados.Repositories;

public class PessoaRepository : IPessoaRepository
{
    private readonly ApplicationDbContext _context;

    public PessoaRepository(ApplicationDbContext context)
    {
        _context = context;
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
        return await _context.Pessoa.ToListAsync();
    }

    public async Task<PessoaEntity> ObterPessoaAsync(int id)
    {
        return await
            _context.Pessoa.Where(e => e.IdPessoa == id).FirstOrDefaultAsync();
    }

    public async Task<PessoaEntity> DeletarPessoaAsync(int id)
    {
        var pessoa = await ObterPessoaAsync(id);

        if (pessoa == null)
        {
            return null;
        }

        _context.Pessoa.Remove(pessoa);

        await _context.SaveChangesAsync();

        return pessoa;
    }
}