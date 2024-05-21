using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class AtualizarTipoRegistroRequestHandler : IRequestHandler<AtualizarTipoRegistroRequest, Result<AtualizarTipoRegistroResponse>>
{
    private readonly ILogger<AtualizarTipoRegistroRequestHandler> _logger;
    private readonly ITipoRegistroRepository _tiporegistroRepository;

    public AtualizarTipoRegistroRequestHandler (ITipoRegistroRepository tipoRegistroRepository, ILogger<AtualizarTipoRegistroRequestHandler> logger){
        _logger = logger;
        _tiporegistroRepository = tipoRegistroRepository;
    }

    public Task<Result<AtualizarTipoRegistroResponse>> Handle(AtualizarTipoRegistroRequest request, CancellationToken cancellationToken)
    {
        var tipo = new TipoRegistroEntity(){
                IdTipoRegistro = request.IdTipoRegistro,
                NomeTipo = request.NomeTipo
            };

        _tiporegistroRepository.AtualizarTipoRegistroAsync(tipo);
        return Task.FromResult(Result.Success(new AtualizarTipoRegistroResponse(tipo.IdTipoRegistro,tipo.NomeTipo)));  
    }
}
