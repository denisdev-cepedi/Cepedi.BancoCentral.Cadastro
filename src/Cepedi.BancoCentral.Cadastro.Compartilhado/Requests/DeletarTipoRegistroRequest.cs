using Cepedi.BancoCentral.Cadastro.Shareable.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Shareable.Requests;

public class DeletarTipoRegistroRequest : IRequest<Result<DeletarTipoRegistroResponse>>
{
    public int IdTipoRegistro { get; set; }

}
