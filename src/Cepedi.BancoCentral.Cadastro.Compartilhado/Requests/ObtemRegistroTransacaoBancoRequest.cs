using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using OperationResult;
namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
public class ObtemRegistroTransacaoBancoRequest : IRequest<Result<ObtemRegistroTransacaoBancoResponse>>
{
    public int IdRegistro { get; set; }

}
