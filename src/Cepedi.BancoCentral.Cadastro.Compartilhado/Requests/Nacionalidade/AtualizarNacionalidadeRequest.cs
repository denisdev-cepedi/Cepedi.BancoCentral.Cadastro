using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Requests.Nacionalidade;

public class AtualizarNacionalidadeRequest : IRequest<Result<AtualizarNacionalidadeResponse>>
{
    public int Id { get; set; }
    public string Descricao { get; set; }
}
