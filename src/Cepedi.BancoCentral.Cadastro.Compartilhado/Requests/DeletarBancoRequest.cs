using Cepedi.BancoCentral.Cadastro.Shareable.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Shareable.Requests;

public class DeletarBancoRequest : IRequest<Result<DeletarBancoResponse>>
{
    public int IdBanco { get; set; }
}
