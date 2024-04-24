using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Requests.Endereco;

public class DeletarEnderecoRequest : IRequest<Result<DeletarEnderecoResponse>>
{
    public int Id { get; set; }
}
