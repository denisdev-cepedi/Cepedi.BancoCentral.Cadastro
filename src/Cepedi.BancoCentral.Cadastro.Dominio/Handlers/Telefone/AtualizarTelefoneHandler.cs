using System.Xml.Resolvers;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class AtualizarTelefoneHandler : IRequestHandler<AtualizarTelefoneRequest, Result<AtualizarTelefoneResponse>>
{
    private readonly ITelefoneRepository _telefoneRepository;
    private readonly ILogger<AtualizarTelefoneHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public AtualizarTelefoneHandler(ITelefoneRepository telefoneRepository, ILogger<AtualizarTelefoneHandler> logger, IUnitOfWork unitOfWork)
    {
        _telefoneRepository = telefoneRepository;
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AtualizarTelefoneResponse>> Handle(AtualizarTelefoneRequest request, CancellationToken cancellationToken)
    {
        var telefoneEntity = await _telefoneRepository.ObterTelefoneAsync(request.IdTelefone);

        if (telefoneEntity == null)
        {
            return Result.Error<AtualizarTelefoneResponse>(new Compartilhado.Excecoes.SemResultadosExcecao());
        }

        telefoneEntity.Atualizar(request.NumeroTelefone);

        await _telefoneRepository.AtualizarTelefoneAsync(telefoneEntity);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success(new AtualizarTelefoneResponse(telefoneEntity.NumeroTelefone));
    }
}
