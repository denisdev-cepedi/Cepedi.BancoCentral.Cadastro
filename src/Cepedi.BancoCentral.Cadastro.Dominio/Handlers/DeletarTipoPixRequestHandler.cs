using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class DeletarTipoPixRequestHandler
    : IRequestHandler<DeletarTipoPixRequest, Result<DeletarTipoPixResponse>>
{
    private readonly ILogger<DeletarTipoPixRequestHandler> _logger;
    private readonly ITipoPixRepository _tipoPixRepository;

    public DeletarTipoPixRequestHandler(ITipoPixRepository tipoPixRepository, ILogger<DeletarTipoPixRequestHandler> logger)
    {
        _tipoPixRepository = tipoPixRepository;
        _logger = logger;
    }

    public async Task<Result<DeletarTipoPixResponse>> Handle(DeletarTipoPixRequest request, CancellationToken cancellationToken)
    {
        var tipoPix = await _tipoPixRepository.ObterTipoPixAsync(request.IdTipoPix);

        if (tipoPix == null)
        {
            return Result.Error<DeletarTipoPixResponse>(new Compartilhado.
                Excecoes.SemResultadosExcecao());
        }

        await _tipoPixRepository.DeletarTipoPixAsync(tipoPix.IdTipoPix);
        return Result.Success(new DeletarTipoPixResponse(tipoPix.IdTipoPix, tipoPix.NomeTipo));
    }
}
