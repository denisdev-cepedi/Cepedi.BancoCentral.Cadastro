using System.Runtime.CompilerServices;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio;

public class CriarTipoRegistroRequestHandler : IRequestHandler<CriarTipoRegistroRequest, Result<CriarTipoRegistroResponse>>
{
    private readonly ILogger<CriarTipoRegistroRequestHandler> _logger;
    private readonly ITipoRegistroRepository _tiporegistroRepository;

    public CriarTipoRegistroRequestHandler (ITipoRegistroRepository tipoRegistroRepository, ILogger<CriarTipoRegistroRequestHandler> logger){
        _logger = logger;
        _tiporegistroRepository = tipoRegistroRepository;
    }


    public async Task<Result<CriarTipoRegistroResponse>> Handle(CriarTipoRegistroRequest request, CancellationToken cancellationToken)
    {
       
            var tipo = new TipoRegistroEntity(){
                NomeTipo = request.NomeTipo
            };

            await _tiporegistroRepository.CriarTipoRegistroAsync(tipo);
            return Result.Success(new CriarTipoRegistroResponse(tipo.IdTipoRegistro,tipo.NomeTipo));

        
    }
}
