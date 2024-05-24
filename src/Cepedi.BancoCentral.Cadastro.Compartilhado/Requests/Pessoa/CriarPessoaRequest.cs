using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
public class CriarPessoaRequest : IRequest<Result<CriarPessoaResponse>>
{
    public string Nome { get; set; } = default!;

    public DateTime DataNascimento { get; set; }

    public string Cpf { get; set; } = default!;

    public int Genero { get; set; } = default!;
    public int EstadoCivil { get; set; } = default!;
    public int Nacionalidade { get; set; } = default!;
}
