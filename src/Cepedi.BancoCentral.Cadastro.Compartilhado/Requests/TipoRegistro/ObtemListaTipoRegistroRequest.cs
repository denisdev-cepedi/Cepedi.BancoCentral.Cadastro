using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using OperationResult;
namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;

public class ObtemListaTipoRegistroRequest : IRequest<Result<List<ObtemTipoRegistroResponse>>>
{

}
