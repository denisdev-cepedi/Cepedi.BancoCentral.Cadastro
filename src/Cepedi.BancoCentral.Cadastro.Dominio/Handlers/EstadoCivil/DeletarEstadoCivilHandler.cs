using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class DeletarEstadoCivilHandler : IRequestHandler<DeletarEstadoCivilRequest, Result<DeletarEstadoCivilResponse>>
{
    private readonly ILogger<DeletarEstadoCivilHandler> _logger;
    private readonly IEstadoCivilRepository _estadoCivilRepository;

    public DeletarEstadoCivilHandler(IEstadoCivilRepository estadoCivilRepository, ILogger<DeletarEstadoCivilHandler> logger)
    {
        _estadoCivilRepository = estadoCivilRepository;
        _logger = logger;
    }

    public async Task<Result<DeletarEstadoCivilResponse>> Handle(DeletarEstadoCivilRequest request, CancellationToken cancellationToken)
    {
        var estadoCivil = await _estadoCivilRepository.ObterEstadoCivilAsync(request.Id);

        if (estadoCivil == null)
        {
            return Result.Error<DeletarEstadoCivilResponse>(new Compartilhado.
                Excecoes.SemResultadosExcecao());
        }

        await _estadoCivilRepository.DeletarEstadoCivilAsync(estadoCivil);

        return Result.Success(new DeletarEstadoCivilResponse(estadoCivil.NomeEstadoCivil));
    }
}
