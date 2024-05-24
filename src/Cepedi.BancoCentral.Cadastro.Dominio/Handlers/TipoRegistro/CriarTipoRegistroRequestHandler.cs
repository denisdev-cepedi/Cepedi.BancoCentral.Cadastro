using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Shareable.Requests;
using Cepedi.BancoCentral.Cadastro.Shareable.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class CriarTipoRegistroRequestHandler : IRequestHandler<CriarTipoRegistroRequest, Result<CriarTipoRegistroResponse>>
{
    private readonly ILogger<CriarTipoRegistroRequestHandler> _logger;
    private readonly ITipoRegistroRepository _tiporegistroRepository;

    private readonly IUnitOfWork _unitOfWork;

    public CriarTipoRegistroRequestHandler (ITipoRegistroRepository tipoRegistroRepository, 
    ILogger<CriarTipoRegistroRequestHandler> logger, IUnitOfWork unitOfWork){
        _logger = logger;
        _tiporegistroRepository = tipoRegistroRepository;
        _unitOfWork = unitOfWork;
    }


    public async Task<Result<CriarTipoRegistroResponse>> Handle(CriarTipoRegistroRequest request, CancellationToken cancellationToken)
    {
        var tipo = new TipoRegistroEntity(){
                NomeTipo = request.NomeTipo
            };

        await _tiporegistroRepository.CriarTipoRegistroAsync(tipo);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(new CriarTipoRegistroResponse(tipo.IdTipoRegistro,tipo.NomeTipo));

    }
}
