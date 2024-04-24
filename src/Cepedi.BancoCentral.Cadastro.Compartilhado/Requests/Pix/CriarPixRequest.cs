using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Requests.Pix;

public class CriarPixRequest : IRequest<Result<CriarPixResponse>>
{
    public string ChavePix { get; set; }
    public string TipoPix { get; set; }
    public int IdCliente { get; set; }
}
