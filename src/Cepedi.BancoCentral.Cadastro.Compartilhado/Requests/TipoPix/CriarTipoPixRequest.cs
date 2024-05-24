using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;

public class CriarTipoPixRequest : IRequest<Result<CriarTipoPixResponse>>
{
    public string TipoPix {get; set;}= default!;

}
