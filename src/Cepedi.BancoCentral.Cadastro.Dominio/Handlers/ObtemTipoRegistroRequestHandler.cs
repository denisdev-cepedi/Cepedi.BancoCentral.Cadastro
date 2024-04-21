using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class ObtemTipoRegistroRequestHandler : IRequestHandler<ObtemTipoRegistroRequest, Result<ObtemTipoRegistroResponse>>
{
    private readonly ILogger<ObtemTipoRegistroRequestHandler> _logger;
    private readonly ITipoRegistroRepository _tiporegistroRepository;

    public ObtemTipoRegistroRequestHandler(ITipoRegistroRepository tipoRegistroRepository, ILogger<ObtemTipoRegistroRequestHandler> logger)
    {
        _logger = logger;
        _tiporegistroRepository = tipoRegistroRepository;
    }
    public async Task<Result<ObtemTipoRegistroResponse>> Handle(ObtemTipoRegistroRequest request, CancellationToken cancellationToken)
    {
        try{
            var tipoRegistro = await _tiporegistroRepository.ObterTipoRegistroAsync(request.IdTipoRegistro);
            if(tipoRegistro == null){
                return Result.Error<ObtemTipoRegistroResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(
                    (Compartilhado.Enums.Cadastro.SemResultados)));
            }
            return Result.Success(new ObtemTipoRegistroResponse(tipoRegistro.IdTipoRegistro, tipoRegistro.NomeTipo));

        }catch{
            _logger.LogError("Ocorreu um erro durante a execução");
            return Result.Error<ObtemTipoRegistroResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(
                (Compartilhado.Enums.Cadastro.ErroLeituraTipoRegistro)));

        }

    }
}
