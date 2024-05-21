using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class CriarEmailHandler : IRequestHandler<CriarEmailRequest, Result<CriarEmailResponse>>
{
    private readonly ILogger<CriarEmailHandler> _logger;
    private readonly IEmailRepository _emailRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CriarEmailHandler(IEmailRepository emailRepository, ILogger<CriarEmailHandler> logger, IUnitOfWork unitOfWork)
    {
        _emailRepository = emailRepository;
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<CriarEmailResponse>> Handle(CriarEmailRequest request, CancellationToken cancellationToken)
    {
        var email = new EmailEntity()
        {
            EnderecoEmail = request.EnderecoEmail,
            IdPessoa = request.IdPessoa
        };

        await _emailRepository.CriarEmailAsync(email);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success(new CriarEmailResponse(email.IdEmail, email.EnderecoEmail));
    }
}

