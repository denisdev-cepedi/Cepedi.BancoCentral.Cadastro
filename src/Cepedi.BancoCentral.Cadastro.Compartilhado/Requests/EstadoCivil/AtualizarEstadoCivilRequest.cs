using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;

public class AtualizarEstadoCivilRequest : IRequest<Result<AtualizarEstadoCivilResponse>>
{
    public int Id { get; set; }
    public string Descricao { get; set; }
}
