﻿using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.BancoCentral.Cadastro.Dados.Repositories;

public class TipoRegistroRepository : ITipoRegistroRepository
{
    private readonly ApplicationDbContext _context;

    public TipoRegistroRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TipoRegistroEntity> AtualizarTipoRegistroAsync(TipoRegistroEntity TipoRegistro)
    {
        _context.TipoRegistro.Update(TipoRegistro);
        await _context.SaveChangesAsync();
        return TipoRegistro;


    }

    public async Task<TipoRegistroEntity> CriarTipoRegistroAsync(TipoRegistroEntity TipoRegistro)
    {
        _context.TipoRegistro.Add(TipoRegistro);

        await _context.SaveChangesAsync();

        return TipoRegistro;
    }

    public async Task<TipoRegistroEntity> DeletarTipoRegistroAsync(TipoRegistroEntity TipoRegistro)
    {
        _context.TipoRegistro.Remove(TipoRegistro);
        await _context.SaveChangesAsync();
        return TipoRegistro;
    }

    public async Task<TipoRegistroEntity> ObterTipoRegistroAsync(int id)
    {
        return await _context.TipoRegistro.Where(e => e.IdTipoRegistro == id).FirstOrDefaultAsync();
    }

    public async Task<List<TipoRegistroEntity>> ObterTipoRegistroAsync()
    {
        return await _context.TipoRegistro.ToListAsync();

    }
}
