using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class AtualizarEstadoCivilHandler : IRequestHandler<AtualizarEstadoCivilRequest, Result<AtualizarEstadoCivilResponse>>
{
    private readonly IEstadoCivilRepository _estadoCivilRepository;
    private readonly ILogger<AtualizarEstadoCivilHandler> _logger;

    public AtualizarEstadoCivilHandler(IEstadoCivilRepository estadoCivilRepository, ILogger<AtualizarEstadoCivilHandler> logger)
    {
        _estadoCivilRepository = estadoCivilRepository;
        _logger = logger;
    }

    public async Task<Result<AtualizarEstadoCivilResponse>> Handle(AtualizarEstadoCivilRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var estadoCivilEntity = await _estadoCivilRepository.ObterEstadoCivilAsync(request.Id);

            if (estadoCivilEntity == null)
            {
                return Result.Error<AtualizarEstadoCivilResponse>(new Compartilhado.Excecoes.SemResultadosExcecao());
            }

            estadoCivilEntity.Atualizar(request.Descricao);

            await _estadoCivilRepository.AtualizarEstadoCivilAsync(estadoCivilEntity);

            return Result.Success(new AtualizarEstadoCivilResponse(estadoCivilEntity.NomeEstadoCivil));
        }
        catch
        {
            _logger.LogError("Ocorreu um erro ao atualizar os estados civis");
            throw;
        }
    }
}
