using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository.Queries;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Cepedi.BancoCentral.Cadastro.Data.Repositories.Queries;

public class BancoQueryRepository : BaseDapperRepository, IBancoQueryRepository
{
    public BancoQueryRepository(IConfiguration configuration) 
        : base(configuration)
    {
    }

    public async Task<List<BancoEntity>> ObterBancoAsync(string cnpj)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@Cnpj", cnpj, System.Data.DbType.String);

        var sql = @"SELECT 
                        IdBanco, 
                        NomeReal,
                        NomeFantasia,
                        Cnpj,
                        DataCriacao
                    FROM Banco WITH(NOLOCK)
                    Where
                        Cnpj = @Cnpj";

        var retorno = await ExecuteQueryAsync
            <BancoEntity>(sql, parametros);

        return retorno.ToList();
    }
}
