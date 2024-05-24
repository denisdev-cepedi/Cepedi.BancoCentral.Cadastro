using Cepedi.BancoCentral.Cadastro.Shareable.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Shareable.Requests;

public class ObtemListaBancoRequest : IRequest<Result<List<ObtemBancoResponse>>>
{
    
}
