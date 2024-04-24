using Cepedi.BancoCentral.Cadastro.Shareable.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Shareable.Requests;

public class ObtemBancoRequest : IRequest<Result<ObtemBancoResponse>>
{
    public int IdBanco { get; set; }
}
