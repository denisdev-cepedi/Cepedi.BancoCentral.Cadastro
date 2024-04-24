using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Requests.EstadoCivil;

public class DeletarEstadoCivilRequest : IRequest<Result<DeletarEstadoCivilResponse>>
{
    public int Id { get; set; }
}
