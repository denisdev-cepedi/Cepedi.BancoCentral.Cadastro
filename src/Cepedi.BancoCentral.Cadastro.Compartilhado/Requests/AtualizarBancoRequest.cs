using Cepedi.BancoCentral.Cadastro.Shareable.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Shareable.Requests;

public class AtualizarBancoRequest : IRequest<Result<AtualizarBancoResponse>>
{
    public int IdBanco { get; set; }
    public string NomeFantasia { get; set; } = default!;
    public string NomeReal { get; set; } = default!;
    public string Cnpj { get; set; } = default!;
    public DateTime DataCriacao { get; set; } = default!;
}
