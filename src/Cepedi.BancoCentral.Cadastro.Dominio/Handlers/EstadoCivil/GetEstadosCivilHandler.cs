using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class GetEstadosCivilHandler : IRequestHandler<GetEstadosCivilRequest, Result<List<GetEstadosCivilResponse>>>
{
    private readonly ILogger<GetEstadosCivilHandler> _logger;
    private readonly IEstadoCivilRepository _estadoCivilRepository;

    public GetEstadosCivilHandler(IEstadoCivilRepository estadoCivilRepository, ILogger<GetEstadosCivilHandler> logger)
    {
        _estadoCivilRepository = estadoCivilRepository;
        _logger = logger;
    }

    public async Task<Result<List<GetEstadosCivilResponse>>> Handle(GetEstadosCivilRequest request,
        CancellationToken cancellationToken)
    {
        var estadosCivil = await _estadoCivilRepository.GetEstadosCivilAsync();
        return Result.Success(estadosCivil.Select(e => new GetEstadosCivilResponse(e.NomeEstadoCivil)).ToList());
    }
}
