using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio;

// IRequestHandler<CriarTipoRegistroRequest, Result<int>>
public class DeletarTipoRegistroRequestHandler : IRequestHandler<DeletarTipoRegistroRequest, Result<DeletarTipoRegistroResponse>>
{
    private readonly ILogger<DeletarTipoRegistroRequestHandler> _logger;
    private readonly ITipoRegistroRepository _tiporegistroRepository;

    public DeletarTipoRegistroRequestHandler(ITipoRegistroRepository tipoRegistroRepository, ILogger<DeletarTipoRegistroRequestHandler> logger)
    {
        _logger = logger;
        _tiporegistroRepository = tipoRegistroRepository;
    }

    public async Task<Result<DeletarTipoRegistroResponse>> Handle(DeletarTipoRegistroRequest request, CancellationToken cancellationToken)
    {
        try{
            var cursoEncontrado = await _tiporegistroRepository.ObterTipoRegistroAsync(request.IdTipoRegistro);
            await _tiporegistroRepository.DeletarTipoRegistroAsync(cursoEncontrado);
            return Result.Success(new DeletarTipoRegistroResponse(cursoEncontrado.IdTipoRegistro,cursoEncontrado.NomeTipo));


        }catch{
            _logger.LogError("Ocorreu um erro durante a execução");
            return Result.Error<DeletarTipoRegistroResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(
                (Compartilhado.Enums.Cadastro.ErroDeletarTipoRegistro)));

        }
    }
}
