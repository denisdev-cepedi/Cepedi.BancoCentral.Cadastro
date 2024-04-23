using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.BancoCentral.Cadastro.Dados.Repositories;

public class PixRepository : IPixRepository
{
    private readonly ApplicationDbContext _context;

    public PixRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PixEntity> CriarPixAsync(PixEntity pix)
    {
        
    }


}
