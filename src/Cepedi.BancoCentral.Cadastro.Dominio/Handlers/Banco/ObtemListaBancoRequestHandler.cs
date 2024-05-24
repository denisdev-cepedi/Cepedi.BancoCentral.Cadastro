using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Shareable.Requests;
using Cepedi.BancoCentral.Cadastro.Shareable.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class ObtemListaBancoRequestHandler : IRequestHandler<ObtemListaBancoRequest, Result<List<ObtemBancoResponse>>>
{
    private readonly ILogger<ObtemListaBancoRequestHandler> _logger;
    private readonly IBancoRepository _bancoRepository;
    
    public ObtemListaBancoRequestHandler(IBancoRepository bancoRepository, ILogger<ObtemListaBancoRequestHandler> logger)
    {
        _logger = logger;
        _bancoRepository = bancoRepository;
    }
    
    public async Task<Result<List<ObtemBancoResponse>>> Handle(ObtemListaBancoRequest request, CancellationToken cancellationToken)
    {
        var bancos = await _bancoRepository.ObterBancoAsync();
        _logger.LogInformation($"Obtendo lista de bancos. {bancos.Count} bancos retornados.");
        return Result.Success(bancos.Select(b => new ObtemBancoResponse(b.IdBanco, b.NomeFantasia, b.NomeReal, b.Cnpj, b.DataCriacao)).ToList());
    }
}
