using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class DeletarNacionalidadeHandler : IRequestHandler<DeletarNacionalidadeRequest, Result<DeletarNacionalidadeResponse>>
{
    private readonly ILogger<DeletarNacionalidadeHandler> _logger;
    private readonly INacionalidadeRepository _nacionalidadeRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeletarNacionalidadeHandler(INacionalidadeRepository nacionalidadeRepository, ILogger<DeletarNacionalidadeHandler> logger, IUnitOfWork unitOfWork)
    {
        _nacionalidadeRepository = nacionalidadeRepository;
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<DeletarNacionalidadeResponse>> Handle(DeletarNacionalidadeRequest request, CancellationToken cancellationToken)
    {
        var nacionalidade = await _nacionalidadeRepository.ObterNacionalidadeAsync(request.Id);

        if (nacionalidade == null)
        {
            return Result.Error<DeletarNacionalidadeResponse>(new Compartilhado.
                Excecoes.SemResultadosExcecao());
        }

        await _nacionalidadeRepository.DeletarNacionalidadeAsync(nacionalidade);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success(new DeletarNacionalidadeResponse(nacionalidade.NomeNacionalidade));
    }
}
