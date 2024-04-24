using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Requests.Telefone;

public class AtualizarTelefoneRequest : IRequest<Result<AtualizarTelefoneResponse>>
{
    public int IdTelefone { get; set; }
    public string NumeroTelefone { get; set; }
}
