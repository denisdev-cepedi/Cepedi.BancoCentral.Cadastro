using Cepedi.BancoCentral.Cadastro.Compartilhado.DTO;
using Cepedi.BancoCentral.Cadastro.Shareable.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Shareable.Requests;

public class RegistroTransacaoPessoaTipoTransacaoDtoRequest : IRequest<Result<List<RegistroTransacaoPessoaTipoTransacaoDto>>>{
    public double Saldo { get; set; }

}
