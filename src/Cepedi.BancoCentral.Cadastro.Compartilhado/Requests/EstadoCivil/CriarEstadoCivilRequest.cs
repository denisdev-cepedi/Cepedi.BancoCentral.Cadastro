using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;

public class CriarEstadoCivilRequest : IRequest<Result<CriarEstadoCivilResponse>>
{
    public string Descricao { get; set; }
}
