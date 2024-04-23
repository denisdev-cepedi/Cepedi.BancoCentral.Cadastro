using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class CriarTipoPixRequestHandler 
    : IRequestHandler<CriarTipoPixRequest, Result<CriarTipoPixResponse>>
{
    private readonly ILogger<CriarTipoPixRequestHandler> _logger;
    private readonly ITipoPixRepository _tipoPixRepository;

    public CriarTipoPixRequestHandler(ITipoPixRepository tipoPixRepository, ILogger<CriarTipoPixRequestHandler> logger)
    {
        _tipoPixRepository = tipoPixRepository;
        _logger = logger;
    }

    public async Task<Result<CriarTipoPixResponse>> Handle(CriarTipoPixRequest request, CancellationToken cancellationToken){
        try
        {
            var tipoPix = new TipoPixEntity()
            {
                NomeTipo = request.NomeTipo,
            };

            await _tipoPixRepository.CriarTipoPixAsync(tipoPix);
            return Result.Success(new CriarTipoPixResponse(tipoPix.IdTipoPix, tipoPix.NomeTipo));
        }
        catch (System.Exception)
        {
            _logger.LogError("Ocorreu um erro durante a execução");
            return Result.Error<CriarTipoPixResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(
                (Compartilhado.Enums.Cadastro.ErroGravacaoUsuario)));
        }
    }
}
