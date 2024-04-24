using Cepedi.BancoCentral.Cadastro.Shareable.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Shareable.Requests;

public class AtualizarTipoRegistroRequest : IRequest<Result<AtualizarTipoRegistroResponse>>
{
    public int IdTipoRegistro { get; set; }
    public string NomeTipo { get; set; } = default!;

}
