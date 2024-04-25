using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class GetGenerosHandler : IRequestHandler<GetGenerosRequest, Result<List<GetGenerosResponse>>>
{
    private readonly ILogger<GetGenerosHandler> _logger;
    private readonly IGeneroRepository _generoRepository;

    public GetGenerosHandler(IGeneroRepository generoRepository, ILogger<GetGenerosHandler> logger)
    {
        _generoRepository = generoRepository;
        _logger = logger;
    }

    public async Task<Result<List<GetGenerosResponse>>> Handle(GetGenerosRequest request,
        CancellationToken cancellationToken)
    {
        var generos = await _generoRepository.GetGenerosAsync();
        return Result.Success(generos.Select(g => new GetGenerosResponse(g.NomeGenero)).ToList());
    }
}
