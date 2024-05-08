using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.BancoCentral.Cadastro.Dados.Repositories;

public class EmailRepository : IEmailRepository
{
    private readonly ApplicationDbContext _context;

    public EmailRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<EmailEntity> AtualizarEmailAsync(EmailEntity email)
    {
        _context.Email.Update(email);

        await _context.SaveChangesAsync();

        return email;
    }

    public async Task<EmailEntity> CriarEmailAsync(EmailEntity email)
    {
        _context.Email.Add(email);

        await _context.SaveChangesAsync();

        return email;
    }

    public async Task<EmailEntity> DeletarEmailAsync(EmailEntity email)
    {
        _context.Email.Remove(email);

        await _context.SaveChangesAsync();

        return email;
    }

    public async Task<List<EmailEntity>> GetEmailsAsync()
    {
        return await _context.Email.ToListAsync();
    }

    public async Task<EmailEntity> ObterEmailAsync(int id)
    {
        return await
            _context.Email.Where(e => e.IdEmail == id).FirstOrDefaultAsync();
    }
}
