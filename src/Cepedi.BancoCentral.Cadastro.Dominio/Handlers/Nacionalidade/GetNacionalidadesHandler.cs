using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class GetNacionalidadesHandler : IRequestHandler<GetNacionalidadesRequest, Result<List<GetNacionalidadesResponse>>>
{
    private readonly ILogger<GetNacionalidadesHandler> _logger;
    private readonly INacionalidadeRepository _nacionalidadeRepository;

    public GetNacionalidadesHandler(INacionalidadeRepository nacionalidadeRepository, ILogger<GetNacionalidadesHandler> logger)
    {
        _nacionalidadeRepository = nacionalidadeRepository;
        _logger = logger;
    }

    public async Task<Result<List<GetNacionalidadesResponse>>> Handle(GetNacionalidadesRequest request,
        CancellationToken cancellationToken)
    {
        var nacionalidades = await _nacionalidadeRepository.GetNacionalidadesAsync();
        return Result.Success(nacionalidades.Select(n => new GetNacionalidadesResponse(n.NomeNacionalidade)).ToList());
    }
}

