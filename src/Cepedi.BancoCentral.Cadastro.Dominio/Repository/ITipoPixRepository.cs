using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Repository;

public interface ITipoPixRepository
{
    Task<TipoPixEntity> CriarTipoPixAsync(TipoPixEntity pix);
    Task<TipoPixEntity> ObterTipoPixAsync(int id);
    Task<TipoPixEntity> AtualizarTipoPixAsync(TipoPixEntity pix);
    Task<TipoPixEntity> DeletarTipoPixAsync(int id);
    Task<List<TipoPixEntity>> GetTipoPixsAync();
}
