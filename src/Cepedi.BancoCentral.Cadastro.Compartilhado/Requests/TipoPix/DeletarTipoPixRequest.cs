using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;

public class DeletarTipoPixRequest : IRequest<Result<DeletarTipoPixResponse>>
{
    public int IdTipoPix { get; set; }
     public string TipoPix { get; set; }
}
