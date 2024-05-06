using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Repository;

public interface IEmailRepository
{
    Task<EmailEntity> CriarEmailAsync(EmailEntity email);
    Task<EmailEntity> ObterEmailAsync(int id);
    Task<EmailEntity> AtualizarEmailAsync(EmailEntity email);
    Task<EmailEntity> DeletarEmailAsync(EmailEntity email);
    Task<List<EmailEntity>> GetEmailsAsync();
}
