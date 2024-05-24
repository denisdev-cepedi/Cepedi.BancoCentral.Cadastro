﻿using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class DeletarTipoPixHandler
    : IRequestHandler<DeletarTipoPixRequest, Result<DeletarTipoPixResponse>>
{
    private readonly ITipoPixRepository _tipoPixRepository;
    private readonly ILogger<DeletarTipoPixHandler> _logger;

    public DeletarTipoPixHandler(ITipoPixRepository tipoPixRepository, ILogger<DeletarTipoPixHandler> logger)
    {
        _tipoPixRepository = tipoPixRepository;
        _logger = logger;
    }

    public async Task<Result<DeletarTipoPixResponse>> Handle(DeletarTipoPixRequest request, CancellationToken cancellationToken)
    {
        var tipoPix = await _tipoPixRepository.ObterTipoPixAsync(request.IdTipoPix);

        if (tipoPix == null)
        {
            return Result.Error<DeletarTipoPixResponse>(new Compartilhado.Excecoes.SemResultadosExcecao());
        }

        await _tipoPixRepository.DeletarTipoPixAsync(tipoPix);
        return Result.Success(new DeletarTipoPixResponse(tipoPix.TipoPix));
    }
}
