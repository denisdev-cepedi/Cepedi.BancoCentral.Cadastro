using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;

public class DeletarPessoaRequest : IRequest<Result<DeletarPessoaResponse>>
{
    public int Id { get; set; }

}
