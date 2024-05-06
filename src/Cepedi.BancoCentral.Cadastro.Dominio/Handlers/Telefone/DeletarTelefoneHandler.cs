using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class DeletarTelefoneHandler : IRequestHandler<DeletarTelefoneRequest, Result<DeletarTelefoneResponse>>
{
    private readonly ILogger<DeletarTelefoneHandler> _logger;
    private readonly ITelefoneRepository _telefoneRepository;

    public DeletarTelefoneHandler(ITelefoneRepository telefoneRepository, ILogger<DeletarTelefoneHandler> logger)
    {
        _telefoneRepository = telefoneRepository;
        _logger = logger;
    }

    public async Task<Result<DeletarTelefoneResponse>> Handle(DeletarTelefoneRequest request, CancellationToken cancellationToken)
    {
        var telefone = await _telefoneRepository.ObterTelefoneAsync(request.IdTelefone);

        if (telefone == null)
        {
            return Result.Error<DeletarTelefoneResponse>(new Compartilhado.
                Excecoes.SemResultadosExcecao());
        }

        await _telefoneRepository.DeletarTelefoneAsync(telefone);

        return Result.Success(new DeletarTelefoneResponse(telefone.NumeroTelefone));
    }
}
