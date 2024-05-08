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

    public CriarEmailHandler(IEmailRepository emailRepository, ILogger<CriarEmailHandler> logger)
    {
        _emailRepository = emailRepository;
        _logger = logger;
    }

    public async Task<Result<CriarEmailResponse>> Handle(CriarEmailRequest request, CancellationToken cancellationToken)
    {
        var email = new EmailEntity()
        {
            EnderecoEmail = request.EnderecoEmail,
            IdPessoa = request.IdPessoa
        };

        await _emailRepository.CriarEmailAsync(email);

        return Result.Success(new CriarEmailResponse(email.IdEmail, email.EnderecoEmail));
    }
}

