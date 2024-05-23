using Cepedi.BancoCentral.Cadastro.Compartilhado.DTO;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository.Queries;
using Cepedi.BancoCentral.Cadastro.Shareable.Requests;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio;

public class RegistroTransacaoPessoaTipoTransacaoDTOHandler : IRequestHandler<RegistroTransacaoPessoaTipoTransacaoDtoRequest, Result<List<RegistroTransacaoPessoaTipoTransacaoDto>>>
{
    private readonly ILogger<ObtemListaRegistroTransacaoBancoRequestHandler> _logger;
    private readonly IRegistroTransacaoBancoQueryRepository _registroTransacaoBancoQueryRepository;

    public RegistroTransacaoPessoaTipoTransacaoDTOHandler(ILogger<ObtemListaRegistroTransacaoBancoRequestHandler> logger, IRegistroTransacaoBancoQueryRepository registroTransacaoBancoRepository)
    {
        _logger = logger;
        _registroTransacaoBancoQueryRepository = registroTransacaoBancoRepository;
    }
    public async Task<Result<List<RegistroTransacaoPessoaTipoTransacaoDto>>> Handle(RegistroTransacaoPessoaTipoTransacaoDtoRequest request, CancellationToken cancellationToken)
    {
        var transacoesFiltradas =  await _registroTransacaoBancoQueryRepository.ObterRegistroTransacaoBancoAsync(request.Saldo);
        return Result.Success(transacoesFiltradas);
    }
}
