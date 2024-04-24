using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Requests.GeneroEntity;

public class DeletarGeneroRequest : IRequest<Result<DeletarGeneroResponse>>
{
    public int Id { get; set; }
}
