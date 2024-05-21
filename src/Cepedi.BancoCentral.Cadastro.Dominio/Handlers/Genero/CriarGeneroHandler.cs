using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class CriarGeneroHandler : IRequestHandler<CriarGeneroRequest, Result<CriarGeneroResponse>>
{
    private readonly ILogger<CriarGeneroHandler> _logger;
    private readonly IGeneroRepository _generoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CriarGeneroHandler(IGeneroRepository generoRepository, ILogger<CriarGeneroHandler> logger, IUnitOfWork unitOfWork)
    {
        _generoRepository = generoRepository;
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<CriarGeneroResponse>> Handle(CriarGeneroRequest request, CancellationToken cancellationToken)
    {
        var genero = new GeneroEntity()
        {
            NomeGenero = request.Descricao
        };

        await _generoRepository.CriarGeneroAsync(genero);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success(new CriarGeneroResponse(genero.NomeGenero));
    }
}
