using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio;


public class ObtemListaTipoRegistroRequestHandler : IRequestHandler<ObtemListaTipoRegistroRequest, Result<List<ObtemTipoRegistroResponse>>>
{
    private readonly ILogger<CriarTipoRegistroRequestHandler> _logger;
    private readonly ITipoRegistroRepository _tiporegistroRepository;

    public ObtemListaTipoRegistroRequestHandler (ITipoRegistroRepository tipoRegistroRepository, ILogger<CriarTipoRegistroRequestHandler> logger){
        _logger = logger;
        _tiporegistroRepository = tipoRegistroRepository;
    }
    public async Task<Result<List<ObtemTipoRegistroResponse>>> Handle(ObtemListaTipoRegistroRequest request, CancellationToken cancellationToken)
    {
        var tipos = await _tiporegistroRepository.ObterTipoRegistroAsync();
        return Result.Success(tipos.Select(t => new ObtemTipoRegistroResponse(t.IdTipoRegistro,t.NomeTipo)).ToList());
        

    }
}
