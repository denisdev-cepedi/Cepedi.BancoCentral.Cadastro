using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;

public class ObtemTipoRegistroRequest : IRequest<Result<ObtemTipoRegistroResponse>>
{
    public int IdTipoRegistro { get; set; }

}
