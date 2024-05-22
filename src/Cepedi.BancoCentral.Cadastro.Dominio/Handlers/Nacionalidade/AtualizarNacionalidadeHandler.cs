using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class AtualizarNacionalidadeHandler : IRequestHandler<AtualizarNacionalidadeRequest, Result<AtualizarNacionalidadeResponse>>
{
    private readonly INacionalidadeRepository _nacionalidadeRepository;
    private readonly ILogger<AtualizarNacionalidadeHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public AtualizarNacionalidadeHandler(INacionalidadeRepository nacionalidadeRepository, ILogger<AtualizarNacionalidadeHandler> logger, IUnitOfWork unitOfWork)
    {
        _nacionalidadeRepository = nacionalidadeRepository;
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AtualizarNacionalidadeResponse>> Handle(AtualizarNacionalidadeRequest request, CancellationToken cancellationToken)
    {
        var nacionalidadeEntity = await _nacionalidadeRepository.ObterNacionalidadeAsync(request.Id);

        if (nacionalidadeEntity == null)
        {
            return Result.Error<AtualizarNacionalidadeResponse>(new Compartilhado.Excecoes.SemResultadosExcecao());
        }

        nacionalidadeEntity.Atualizar(request.Descricao);

        await _nacionalidadeRepository.AtualizarNacionalidadeAsync(nacionalidadeEntity);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success(new AtualizarNacionalidadeResponse(nacionalidadeEntity.NomeNacionalidade));
    }
}
