using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Requests.Nacionalidade;

public class DeletarNacionalidadeRequest : IRequest<Result<DeletarNacionalidadeResponse>>
{
    public int Id { get; set; }
}
