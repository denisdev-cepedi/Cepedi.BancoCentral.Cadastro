using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Requests.Endereco;

public class GetEnderecosRequest : IRequest<Result<List<GetEnderecosResponse>>>
{
    
}
