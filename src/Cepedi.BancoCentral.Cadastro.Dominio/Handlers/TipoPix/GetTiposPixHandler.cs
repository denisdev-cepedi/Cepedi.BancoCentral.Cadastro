using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;
/* IRequestHandler<GetTiposPixRequest, Result<List<GetTipoPixResponse>>> */
public class GetTiposPixHandler
    : IRequestHandler<GetTiposPixRequest, Result<List<GetTiposPixResponse>>>
{
    private readonly ILogger<GetTiposPixHandler> _logger;
    private readonly ITipoPixRepository _tipoPixRepository;

    public GetTiposPixHandler(ITipoPixRepository tipoPixRepository, ILogger<GetTiposPixHandler> logger)
    {
        _tipoPixRepository = tipoPixRepository;
        _logger = logger;
    }

    public async Task<Result<List<GetTiposPixResponse>>> Handle(GetTiposPixRequest request, CancellationToken cancellationToken)
    {
        var tipoPix = await _tipoPixRepository.GetTipoPixsAync();
        return Result.Success(tipoPix.Select(p => new GetTiposPixResponse(p.IdTipoPix, p.TipoPix)).ToList());
    }
}
