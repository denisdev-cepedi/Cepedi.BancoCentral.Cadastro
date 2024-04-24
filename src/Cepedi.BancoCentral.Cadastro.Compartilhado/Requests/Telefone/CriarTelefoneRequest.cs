using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;

public class CriarTelefoneRequest : IRequest<Result<CriarTelefoneResponse>>
{
    public string NumeroTelefone { get; set; }
}
