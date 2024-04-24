using Cepedi.BancoCentral.Cadastro.Shareable.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Shareable.Requests;

public class CriarBancoRequest : IRequest<Result<CriarBancoResponse>>
{
    public string NomeFantasia { get; set; } = default!;
    public string Cnpj { get; set; } = default!;
    public DateTime DataCriacao { get; set; } = default!;
}
