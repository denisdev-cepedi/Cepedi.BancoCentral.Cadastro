using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Repository.Queries;

public interface IBancoQueryRepository
{
    Task<List<BancoEntity>> ObterBancoAsync(string cnpj);
}
