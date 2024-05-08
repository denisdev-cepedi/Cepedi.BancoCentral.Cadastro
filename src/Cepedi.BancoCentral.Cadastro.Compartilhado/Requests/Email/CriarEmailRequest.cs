using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
public class CriarEmailRequest : IRequest<Result<CriarEmailResponse>>
{
    public string EnderecoEmail { get; set; } = default!;
    public int IdPessoa { get; set; }
}
