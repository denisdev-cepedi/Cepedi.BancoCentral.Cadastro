using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Shareable.Requests;
using Cepedi.BancoCentral.Cadastro.Shareable.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class DeletarBancoRequestHandler : IRequestHandler<DeletarBancoRequest, Result<DeletarBancoResponse>>
{
    private readonly ILogger<DeletarBancoRequestHandler> _logger;
    private readonly IBancoRepository _bancoRepository;
    
    public DeletarBancoRequestHandler(IBancoRepository bancoRepository, ILogger<DeletarBancoRequestHandler> logger)
    {
        _logger = logger;
        _bancoRepository = bancoRepository;
    }
    
    public async Task<Result<DeletarBancoResponse>> Handle(DeletarBancoRequest request, CancellationToken cancellationToken)
    {
        var banco = await _bancoRepository.ObterBancoAsync(request.IdBanco);
        if (banco == null)
        {
            return Result.Error<DeletarBancoResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(
                (Compartilhado.Enums.Cadastro.ErroDeletarBanco)));
        }
        await _bancoRepository.DeletarBancoAsync(banco);
        _logger.LogInformation($"Deletando banco: {banco.NomeReal}");
        return Result.Success(new DeletarBancoResponse(banco.IdBanco, banco.NomeFantasia, banco.NomeReal, banco.Cnpj, banco.DataCriacao));
    }
}
