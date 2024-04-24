using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Requests.Nacionalidade;

public class CriarNacionalidadeRequest : IRequest<Result<CriarNacionalidadeResponse>>
{
    public string Descricao { get; set; }
}
