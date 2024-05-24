using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;
public class CriarTipoPixHandler
    : IRequestHandler<CriarTipoPixRequest, Result<CriarTipoPixResponse>>
{
    private readonly ITipoPixRepository _tipoPixRepository;
    private readonly ILogger<CriarTipoPixHandler> _logger;

    public CriarTipoPixHandler(ITipoPixRepository tipoPixRepository, ILogger<CriarTipoPixHandler> logger)
    {
        _tipoPixRepository = tipoPixRepository;
        _logger = logger;
    }

    public async Task<Result<CriarTipoPixResponse>> Handle(CriarTipoPixRequest request, CancellationToken cancellationToken)
    {
        var tipoPix = new TipoPixEntity()
        {
            TipoPix = request.TipoPix,
        };

        await _tipoPixRepository.CriarTipoPixAsync(tipoPix);
        return Result.Success(new CriarTipoPixResponse(tipoPix.TipoPix));
    }
}
