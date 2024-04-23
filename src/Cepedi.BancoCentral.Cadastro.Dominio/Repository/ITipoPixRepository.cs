using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Repository;

public interface ITipoPixRepository
{
    Task<TipoPix> CriarPixAsync(TipoPix pix);
    Task<TipoPix> ObterPixAsync(int id);
    Task<TipoPix> AtualizarPixAsync(TipoPix pix);
    Task<TipoPix> DeletarPixAsync(int id);
    Task<List<TipoPix>> GetPixsAync();
}
