using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;

public class AtualizarPixRequest : IRequest<Result<AtualizarPixResponse>>
{
    public int IdPix { get; set; }
    public string ChavePix { get; set; }
    public string TipoPix { get; set; }
}
