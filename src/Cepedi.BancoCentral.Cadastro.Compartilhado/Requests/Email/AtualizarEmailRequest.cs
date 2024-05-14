using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;

public class AtualizarEmailRequest : IRequest<Result<AtualizarEmailResponse>>
{
    public int Id { get; set; }
    public string Email { get; set; }
}
