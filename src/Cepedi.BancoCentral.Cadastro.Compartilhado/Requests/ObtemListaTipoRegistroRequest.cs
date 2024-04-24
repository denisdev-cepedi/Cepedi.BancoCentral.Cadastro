using Cepedi.BancoCentral.Cadastro.Shareable.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Shareable.Requests;

public class ObtemListaTipoRegistroRequest : IRequest<Result<List<ObtemTipoRegistroResponse>>>
{

}
