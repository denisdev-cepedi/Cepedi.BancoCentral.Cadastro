using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Repository.Queries;

public interface IPessoaQueryRepository
{
    Task<List<PessoaEntity>> ObterPessoasAsync(string nome);
}
