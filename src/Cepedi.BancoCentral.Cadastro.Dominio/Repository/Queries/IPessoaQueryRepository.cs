using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;

namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio.Queries;

public interface IPessoaQueryRepository
{
    Task<List<PessoaEntity>> ObterPessoasAsync(string nome);
}
