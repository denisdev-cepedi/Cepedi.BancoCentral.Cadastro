using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Requests.Telefone;

public class DeletarTelefoneRequest : IRequest<Result<DeletarTelefoneResponse>>
{
    public int IdTelefone { get; set; }
}
