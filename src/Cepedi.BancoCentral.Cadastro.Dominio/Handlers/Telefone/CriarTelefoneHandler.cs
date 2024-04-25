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

    public CriarTelefoneHandler(ITelefoneRepository telefoneRepository, ILogger<CriarTelefoneHandler> logger)
    {
        _telefoneRepository = telefoneRepository;
        _logger = logger;
    }

    public async Task<Result<CriarTelefoneResponse>> Handle(CriarTelefoneRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var telefone = new TelefoneEntity()
            {
                IdPessoa = request.IdPessoa,
                NumeroTelefone = request.NumeroTelefone,
            };

            await _telefoneRepository.CriarTelefoneAsync(telefone);

            return Result.Success(new CriarTelefoneResponse(telefone.NumeroTelefone));
        }
        catch
        {
            _logger.LogError("Ocorreu um erro durante a execução");
            return Result.Error<CriarTelefoneResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(
                (Compartilhado.Enums.Cadastro.ErroGravacaoUsuario)));
        }
    }
}
