using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Repository;

public interface ITipoPixRepository
{
    Task<TipoPixEntity> CriarTipoPixAsync(TipoPixEntity tipoPix);
    Task<TipoPixEntity> ObterTipoPixAsync(int id);
    Task<TipoPixEntity> AtualizarTipoPixAsync(TipoPixEntity pix);
    Task<TipoPixEntity> DeletarTipoPixAsync(TipoPixEntity tipoPix);
    Task<List<TipoPixEntity>> GetTipoPixsAync();
}
