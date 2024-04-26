using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;

public class CriarRegistroTransacaoBancoRequest : IRequest<Result<CriarRegistroTransacaoBancoResponse>>, IValida
{
    public DateTime DataRegistro { get; set; }
    public int IdTipoRegistro { get; set; }
    public int IdPessoa { get; set; }
    public int IdBanco { get; set; }
    public double Valor { get; set; }


}
