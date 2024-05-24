using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class CriarTelefoneHandler : IRequestHandler<CriarTelefoneRequest, Result<CriarTelefoneResponse>>
{
    private readonly ILogger<CriarTelefoneHandler> _logger;
    private readonly ITelefoneRepository _telefoneRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CriarTelefoneHandler(ITelefoneRepository telefoneRepository, ILogger<CriarTelefoneHandler> logger, IUnitOfWork unitOfWork)
    {
        _telefoneRepository = telefoneRepository;
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<CriarTelefoneResponse>> Handle(CriarTelefoneRequest request, CancellationToken cancellationToken)
    {
        var telefone = new TelefoneEntity()
        {
            IdPessoa = request.IdPessoa,
            NumeroTelefone = request.NumeroTelefone,
        };

        await _telefoneRepository.CriarTelefoneAsync(telefone);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success(new CriarTelefoneResponse(telefone.NumeroTelefone));
    }
}
