using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

using MediatR;

public class GetPixsHandler : IRequestHandler<GetPixsRequest, Result<List<GetPixsResponse>>>
{
    private readonly ILogger<GetPixsHandler> _logger;
    private readonly IPixRepository _pixRepository;

    public GetPixsHandler(IPixRepository pixRepository, ILogger<GetPixsHandler> logger)
    {
        _pixRepository = pixRepository;
        _logger = logger;
    }

    public async Task<Result<List<GetPixsResponse>>> Handle(GetPixsRequest request,
        CancellationToken cancellationToken)
    {
        var pixs = await _pixRepository.GetPixsAsync();
        return Result.Success(pixs.Select(p => new GetPixsResponse(p.ChavePix, p.TipoPix)).ToList());
    }
}
