using Cepedi.BancoCentral.Cadastro.Compartilhado.DTO;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Repository.Queries;

public interface IRegistroTransacaoBancoQueryRepository{
Task<List<RegistroTransacaoPessoaTipoTransacaoDto>> ObterRegistroTransacaoBancoAsync(double saldo);
}
