using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class AtualizarPixHandler : IRequestHandler<AtualizarPixRequest, Result<AtualizarPixResponse>>
{
    private readonly IPixRepository _pixRepository;
    private readonly ILogger<AtualizarPixHandler> _logger;

    public AtualizarPixHandler(IPixRepository pixRepository, ILogger<AtualizarPixHandler> logger)
    {
        _pixRepository = pixRepository;
        _logger = logger;
    }

    public async Task<Result<AtualizarPixResponse>> Handle(AtualizarPixRequest request, CancellationToken cancellationToken)
    {
        var pixEntity = await _pixRepository.ObterPixAsync(request.IdPix);

        if (pixEntity == null)
        {
            return Result.Error<AtualizarPixResponse>(new Compartilhado.Excecoes.SemResultadosExcecao());
        }

        pixEntity.Atualizar(request.ChavePix, request.TipoPix);

        await _pixRepository.AtualizarPixAsync(pixEntity);

        return Result.Success(new AtualizarPixResponse(pixEntity.ChavePix, pixEntity.TipoPix));
    }
}
