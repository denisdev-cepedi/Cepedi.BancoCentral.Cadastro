using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Requests.GeneroEntity;

public class CriarGeneroRequest : IRequest<Result<CriarGeneroResponse>>
{
    public string Descricao { get; set; }
}
