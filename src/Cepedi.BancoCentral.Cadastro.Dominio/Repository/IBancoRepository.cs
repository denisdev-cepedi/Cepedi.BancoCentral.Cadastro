using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Repository;

public interface IBancoRepository
{
    Task<BancoEntity> CriarBancoAsync(BancoEntity banco);
    Task<BancoEntity> ObterBancoAsync(int id);
    Task<List<BancoEntity>> ObterBancoAsync();
    Task<BancoEntity> AtualizarBancoAsync(BancoEntity banco);
    Task<BancoEntity> DeletarBancoAsync(BancoEntity banco);
}
