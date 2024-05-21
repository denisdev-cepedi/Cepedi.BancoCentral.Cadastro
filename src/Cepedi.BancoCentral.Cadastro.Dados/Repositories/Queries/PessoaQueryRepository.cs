using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio.Queries;
using Dapper;
using Microsoft.Extensions.Configuration;
 
namespace Cepedi.BancoCentral.Cadastro.Data.Repositories.Queries;

public class PessoaQueryRepository : BaseDapperRepository, IPessoaQueryRepository
{
    public PessoaQueryRepository(IConfiguration configuration) 
        : base(configuration)
    {
    }

    public async Task<List<PessoaEntity>> ObterPessoasAsync(string nome)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@Nome", nome, System.Data.DbType.String);

        var sql = @"SELECT 
                        IdPessoa, 
                        Nome,
                        Cpf
                    FROM Pessoa WITH(NOLOCK)
                    Where
                        Nome = @Nome";

        var retorno = await ExecuteQueryAsync
            <PessoaEntity>(sql, parametros);

        return retorno.ToList();
    }
}
