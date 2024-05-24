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

    private readonly IUnitOfWork _unitOfWork;

    public AtualizarTipoRegistroRequestHandler (ITipoRegistroRepository tipoRegistroRepository, 
    ILogger<AtualizarTipoRegistroRequestHandler> logger, IUnitOfWork unitOfWork){
        _logger = logger;
        _tiporegistroRepository = tipoRegistroRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AtualizarTipoRegistroResponse>> Handle(AtualizarTipoRegistroRequest request, CancellationToken cancellationToken)
    {
        var tipo = await _tiporegistroRepository.ObterTipoRegistroAsync(request.IdTipoRegistro);
        if (tipo == null)
        {
            return Result.Error<AtualizarTipoRegistroResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao((Compartilhado.Enums.Cadastro.DadosInvalidos)));
        }
        
        tipo.AtualizarTipoRegistroAsync(request);
        await _tiporegistroRepository.AtualizarTipoRegistroAsync(tipo);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(new AtualizarTipoRegistroResponse(tipo.IdTipoRegistro,tipo.NomeTipo));  
    }
}
