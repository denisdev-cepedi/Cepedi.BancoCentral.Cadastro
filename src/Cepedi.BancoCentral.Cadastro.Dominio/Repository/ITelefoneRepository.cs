using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Repository;

public interface ITelefoneRepository
{
    Task<TelefoneEntity> CriarTelefoneAsync(TelefoneEntity telefone);
    Task<TelefoneEntity> ObterTelefoneAsync(int id);
    Task<TelefoneEntity> AtualizarTelefoneAsync(TelefoneEntity telefone);
    Task<TelefoneEntity> DeletarTelefoneAsync(int id);
    Task<List<TelefoneEntity>> GetTelefonesAsync();
}
