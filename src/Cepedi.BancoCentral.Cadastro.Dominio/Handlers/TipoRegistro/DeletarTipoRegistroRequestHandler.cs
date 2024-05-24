﻿using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Shareable.Requests;
using Cepedi.BancoCentral.Cadastro.Shareable.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

// IRequestHandler<CriarTipoRegistroRequest, Result<int>>
public class DeletarTipoRegistroRequestHandler : IRequestHandler<DeletarTipoRegistroRequest, Result<DeletarTipoRegistroResponse>>
{
    private readonly ILogger<DeletarTipoRegistroRequestHandler> _logger;
    private readonly ITipoRegistroRepository _tiporegistroRepository;

    private readonly IUnitOfWork _unitOfWork;

    public DeletarTipoRegistroRequestHandler(ITipoRegistroRepository tipoRegistroRepository, 
    ILogger<DeletarTipoRegistroRequestHandler> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _tiporegistroRepository = tipoRegistroRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<DeletarTipoRegistroResponse>> Handle(DeletarTipoRegistroRequest request, CancellationToken cancellationToken)
    {
       
        var tipoEncontrado = await _tiporegistroRepository.ObterTipoRegistroAsync(request.IdTipoRegistro);
        if (tipoEncontrado == null)
        {
            return Result.Error<DeletarTipoRegistroResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(
                (Compartilhado.Enums.Cadastro.ErroDeletarTipoRegistro)));
        }
        await _tiporegistroRepository.DeletarTipoRegistroAsync(tipoEncontrado);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(new DeletarTipoRegistroResponse(tipoEncontrado.IdTipoRegistro,tipoEncontrado.NomeTipo));
        
    }
}
