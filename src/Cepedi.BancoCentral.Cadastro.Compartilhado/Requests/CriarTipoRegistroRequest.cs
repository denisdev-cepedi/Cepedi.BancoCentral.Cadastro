using Cepedi.BancoCentral.Cadastro.Shareable.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Shareable.Requests;


public class CriarTipoRegistroRequest : IRequest<Result<CriarTipoRegistroResponse>>
{
    public string NomeTipo { get; set; } = default!;

}
