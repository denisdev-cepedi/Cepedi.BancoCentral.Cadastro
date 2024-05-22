using Cepedi.BancoCentral.Cadastro.Compartilhado.DTO;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository.Queries;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Cepedi.BancoCentral.Cadastro.Data.Repositories.Queries;

public class RegistroTransacaoBancoQueryRepository : BaseDapperRepository, IRegistroTransacaoBancoQueryRepository
{
    public RegistroTransacaoBancoQueryRepository(IConfiguration configuration) : base(configuration)
    {

    }

    public async Task<List<RegistroTransacaoPessoaTipoTransacaoDto>> ObterRegistroTransacaoBancoAsync(double saldo)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@Saldo", saldo, System.Data.DbType.Double);

        var sql = @"SELECT 
                rtb.IdRegistro as IdRegistro,
                tr.NomeTipo as NomeTipoRegistro,
                p.Nome as NomePessoa,
                rtb.Valor as Valor
                FROM 
                    RegistroTransacaoBanco rtb
                JOIN 
                    TipoRegistro tr ON rtb.IdTipoRegistro = tr.IdTipoRegistro
                JOIN 
                    Pessoa p ON rtb.IdPessoa = p.IdPessoa
                WHERE 
                    rtb.Valor >= @Saldo";

        return (await ExecuteQueryAsync<RegistroTransacaoPessoaTipoTransacaoDto>(sql, parametros)).ToList();

    }
}
