using Cepedi.BancoCentral.Cadastro.Shareable.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Shareable.Requests;

public class ObtemTipoRegistroRequest : IRequest<Result<ObtemTipoRegistroResponse>>
{
    public int IdTipoRegistro { get; set; }

}
