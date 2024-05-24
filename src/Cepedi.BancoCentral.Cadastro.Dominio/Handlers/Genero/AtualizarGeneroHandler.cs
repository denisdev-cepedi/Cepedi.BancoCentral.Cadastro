using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class AtualizarGeneroHandler : IRequestHandler<AtualizarGeneroRequest, Result<AtualizarGeneroResponse>>
{
    private readonly IGeneroRepository _generoRepository;
    private readonly ILogger<AtualizarGeneroHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public AtualizarGeneroHandler(IGeneroRepository generoRepository, ILogger<AtualizarGeneroHandler> logger, IUnitOfWork unitOfWork)
    {
        _generoRepository = generoRepository;
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AtualizarGeneroResponse>> Handle(AtualizarGeneroRequest request, CancellationToken cancellationToken)
    {
        var generoEntity = await _generoRepository.ObterGeneroAsync(request.Id);

        if (generoEntity == null)
        {
            return Result.Error<AtualizarGeneroResponse>(new Compartilhado.Excecoes.SemResultadosExcecao());
        }

        generoEntity.Atualizar(request.Descricao);

        await _generoRepository.AtualizarGeneroAsync(generoEntity);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success(new AtualizarGeneroResponse(generoEntity.NomeGenero));
    }
}
