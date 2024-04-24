using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Requests.GeneroEntity;

public class AtualizarGeneroRequest : IRequest<Result<AtualizarGeneroResponse>>
{
    public int Id { get; set; }
    public string Descricao { get; set; }
}
