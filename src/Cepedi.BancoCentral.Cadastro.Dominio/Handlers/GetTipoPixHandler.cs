using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class GetTipoPixHandler
    : IRequestHandler<GetTipoPixRequest, Result<List<GetTipoPixResponse>>>
{
    private readonly ILogger<GetTipoPixHandler> _logger;
    private readonly ITipoPixRepository _tipoPixRepository;

    public GetTipoPixHandler(ITipoPixRepository tipoPixRepository, ILogger<GetTipoPixHandler> logger)
    {
        _tipoPixRepository = tipoPixRepository;
        _logger = logger;
    }

    public async Task<Result<List<GetTipoPixResponse>>> Handle(GetTipoPixRequest request, CancellationToken cancellationToken)
    {
        var tipoPix = await _tipoPixRepository.GetTipoPixsAync();
        return Result.Success(tipoPix.Select(p => new GetTipoPixResponse(p.IdTipoPix, p.NomeTipo)).ToList());
    }
}
