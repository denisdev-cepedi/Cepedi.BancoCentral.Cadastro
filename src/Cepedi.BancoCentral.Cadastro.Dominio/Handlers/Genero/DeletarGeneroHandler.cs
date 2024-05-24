using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class DeletarGeneroHandler : IRequestHandler<DeletarGeneroRequest, Result<DeletarGeneroResponse>>
{
    private readonly ILogger<DeletarGeneroHandler> _logger;
    private readonly IGeneroRepository _generoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletarGeneroHandler(IGeneroRepository generoRepository, ILogger<DeletarGeneroHandler> logger, IUnitOfWork unitOfWork)
    {
        _generoRepository = generoRepository;
        _logger = logger;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<DeletarGeneroResponse>> Handle(DeletarGeneroRequest request, CancellationToken cancellationToken)
    {
        var genero = await _generoRepository.ObterGeneroAsync(request.Id);

        if (genero == null)
        {
            return Result.Error<DeletarGeneroResponse>(new Compartilhado.
                Excecoes.SemResultadosExcecao());
        }

        await _generoRepository.DeletarGeneroAsync(genero);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(new DeletarGeneroResponse(genero.NomeGenero));
    }
}
