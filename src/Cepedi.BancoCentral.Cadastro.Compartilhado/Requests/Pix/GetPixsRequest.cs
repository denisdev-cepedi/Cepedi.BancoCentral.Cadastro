using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Requests.Pix;

public class GetPixsRequest : IRequest<Result<List<GetPixsResponse>>>
{
    
}
