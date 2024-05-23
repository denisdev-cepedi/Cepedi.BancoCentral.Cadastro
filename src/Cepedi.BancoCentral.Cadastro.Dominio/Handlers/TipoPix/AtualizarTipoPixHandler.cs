using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class AtualizarTipoPixHandler
    : IRequestHandler<AtualizarTipoPixRequest, Result<AtualizarTipoPixResponse>>
{
    private readonly ILogger<AtualizarTipoPixHandler> _logger;
    private readonly ITipoPixRepository _tipoPixRepository;

    public AtualizarTipoPixHandler(ITipoPixRepository tipoPixRepository, ILogger<AtualizarTipoPixHandler> logger)
    {
        _tipoPixRepository = tipoPixRepository;
        _logger = logger;
    }

    public async Task<Result<AtualizarTipoPixResponse>> Handle(AtualizarTipoPixRequest request, CancellationToken cancellationToken)
    {

        var tipoPixEntity = await _tipoPixRepository.ObterTipoPixAsync(request.IdTipoPix);

        if (tipoPixEntity == null)
        {
            return Result.Error<AtualizarTipoPixResponse>(new Compartilhado.
                Excecoes.SemResultadosExcecao());
        }

        tipoPixEntity.Atualizar(tipoPixEntity.TipoPix);

        await _tipoPixRepository.AtualizarTipoPixAsync(tipoPixEntity);
        return Result.Success(new AtualizarTipoPixResponse(tipoPixEntity.TipoPix));
    }
}
