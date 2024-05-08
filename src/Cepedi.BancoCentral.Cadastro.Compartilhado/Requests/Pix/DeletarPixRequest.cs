using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;

public class DeletarPixRequest : IRequest<Result<DeletarPixResponse>>
{
    public int IdPix { get; set; }
}
