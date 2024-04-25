using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class CriarEstadoCivilHandler : IRequestHandler<CriarEstadoCivilRequest, Result<CriarEstadoCivilResponse>>
{
    private readonly ILogger<CriarEstadoCivilHandler> _logger;
    private readonly IEstadoCivilRepository _estadoCivilRepository;

    public CriarEstadoCivilHandler(IEstadoCivilRepository estadoCivilRepository, ILogger<CriarEstadoCivilHandler> logger)
    {
        _estadoCivilRepository = estadoCivilRepository;
        _logger = logger;
    }

    public async Task<Result<CriarEstadoCivilResponse>> Handle(CriarEstadoCivilRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var estadoCivil = new EstadoCivilEntity()
            {
                NomeEstadoCivil = request.Descricao
            };

            await _estadoCivilRepository.CriarEstadoCivilAsync(estadoCivil);

            return Result.Success(new CriarEstadoCivilResponse(estadoCivil.NomeEstadoCivil));
        }
        catch
        {
            _logger.LogError("Ocorreu um erro durante a execução");
            return Result.Error<CriarEstadoCivilResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(
                (Compartilhado.Enums.Cadastro.ErroGravacaoUsuario)));
        }
    }
}
