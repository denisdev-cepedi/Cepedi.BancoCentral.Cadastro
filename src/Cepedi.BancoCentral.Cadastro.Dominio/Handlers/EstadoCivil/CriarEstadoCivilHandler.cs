using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class CriarEstadoCivilHandler : IRequestHandler<CriarEstadoCivilRequest, Result<CriarEstadoCivilResponse>>
{
    private readonly ILogger<CriarEstadoCivilHandler> _logger;
    private readonly IEstadoCivilRepository _estadoCivilRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CriarEstadoCivilHandler(IEstadoCivilRepository estadoCivilRepository, ILogger<CriarEstadoCivilHandler> logger, IUnitOfWork unitOfWork)
    {
        _estadoCivilRepository = estadoCivilRepository;
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<CriarEstadoCivilResponse>> Handle(CriarEstadoCivilRequest request, CancellationToken cancellationToken)
    {
        var estadoCivil = new EstadoCivilEntity()
        {
            NomeEstadoCivil = request.Descricao
        };

        await _estadoCivilRepository.CriarEstadoCivilAsync(estadoCivil);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success(new CriarEstadoCivilResponse(estadoCivil.NomeEstadoCivil));
    }
}
