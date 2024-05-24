using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Shareable.Requests;
using Cepedi.BancoCentral.Cadastro.Shareable.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class ObtemBancoRequestHandler : IRequestHandler<ObtemBancoRequest, Result<ObtemBancoResponse>>
{
    private readonly ILogger<ObtemBancoRequestHandler> _logger;
    private readonly IBancoRepository _bancoRepository;
    
    public ObtemBancoRequestHandler(IBancoRepository bancoRepository, ILogger<ObtemBancoRequestHandler> logger)
    {
        _logger = logger;
        _bancoRepository = bancoRepository;
    }
    
    public async Task<Result<ObtemBancoResponse>> Handle(ObtemBancoRequest request, CancellationToken cancellationToken)
    {
        var banco = await _bancoRepository.ObterBancoAsync(request.IdBanco);
        if(banco == null){
            return Result.Error<ObtemBancoResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(
                    (Compartilhado.Enums.Cadastro.SemResultados)));
        }
        _logger.LogInformation($"Buscando banco: {banco.NomeReal}");
        return Result.Success(new ObtemBancoResponse(banco.IdBanco, banco.NomeFantasia, banco.NomeReal, banco.Cnpj, banco.DataCriacao));
    }
}
