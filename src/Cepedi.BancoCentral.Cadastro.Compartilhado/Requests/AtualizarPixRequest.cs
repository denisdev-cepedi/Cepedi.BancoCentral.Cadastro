using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;

public class AtualizarPixRequest : IRequest<Result<AtualizarPixResponse>>
{
    public int IdPix { get; set; }
    public string ChavePix {get; set;} = default!;
    public string Agencia {get; set;} = default!;
    public string Conta {get; set;} = default!;
    public string Instituição {get; set;} = default!;
    public int IdTipoPix{get; set;}
}
