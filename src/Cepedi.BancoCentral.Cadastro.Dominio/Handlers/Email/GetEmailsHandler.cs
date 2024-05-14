using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class GetEmailsHandler : IRequestHandler<GetEmailsRequest, Result<List<GetEmailsResponse>>>
{
    private readonly ILogger<GetEmailsHandler> _logger;
    private readonly IEmailRepository _emailRepository;

    public GetEmailsHandler(IEmailRepository emailRepository, ILogger<GetEmailsHandler> logger)
    {
        _emailRepository = emailRepository;
        _logger = logger;
    }

    public async Task<Result<List<GetEmailsResponse>>> Handle(GetEmailsRequest request,
        CancellationToken cancellationToken)
    {
        var emails = await _emailRepository.GetEmailsAsync();
        return Result.Success(emails.Select(e => new GetEmailsResponse(e.EnderecoEmail)).ToList());
    }
}
