using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class GetTelefonesHandler : IRequestHandler<GetTelefonesRequest, Result<List<GetTelefonesResponse>>>
{
    private readonly ILogger<GetTelefonesHandler> _logger;
    private readonly ITelefoneRepository _telefoneRepository;

    public GetTelefonesHandler(ITelefoneRepository telefoneRepository, ILogger<GetTelefonesHandler> logger)
    {
        _telefoneRepository = telefoneRepository;
        _logger = logger;
    }

    public async Task<Result<List<GetTelefonesResponse>>> Handle(GetTelefonesRequest request,
        CancellationToken cancellationToken)
    {
        var telefones = await _telefoneRepository.GetTelefonesAsync();
        return Result.Success(telefones.Select(t => new GetTelefonesResponse(t.NumeroTelefone)).ToList());
    }
}
