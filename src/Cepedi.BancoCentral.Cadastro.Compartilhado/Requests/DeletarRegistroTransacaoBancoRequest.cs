using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;

public class DeletarRegistroTransacaoBancoRequest : IRequest<Result<DeletarRegistroTransacaoBancoResponse>>
{
    public int IdRegistro { get; set; }
    public string Motivo { get; set; } = default!;
}
