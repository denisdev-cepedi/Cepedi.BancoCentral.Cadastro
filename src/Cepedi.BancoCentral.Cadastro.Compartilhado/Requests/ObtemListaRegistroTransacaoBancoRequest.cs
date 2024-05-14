using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using OperationResult;
namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;

public class ObtemListaRegistroTransacaoBancoRequest : IRequest<Result<List<ObtemRegistroTransacaoBancoResponse>>>
{
}
