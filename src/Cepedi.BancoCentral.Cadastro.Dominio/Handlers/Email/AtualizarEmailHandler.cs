using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class AtualizarEmailHandler : IRequestHandler<AtualizarEmailRequest, Result<AtualizarEmailResponse>>
{
    private readonly IEmailRepository _emailRepository;
    private readonly ILogger<AtualizarEmailHandler> _logger;

    public AtualizarEmailHandler(IEmailRepository emailRepository, ILogger<AtualizarEmailHandler> logger)
    {
        _emailRepository = emailRepository;
        _logger = logger;
    }

    public async Task<Result<AtualizarEmailResponse>> Handle(AtualizarEmailRequest request, CancellationToken cancellationToken)
    {
        var emailEntity = await _emailRepository.ObterEmailAsync(request.Id);

        if (emailEntity == null)
        {
            return Result.Error<AtualizarEmailResponse>(new Compartilhado.Excecoes.SemResultadosExcecao());
        }

        emailEntity.Atualizar(request.Email);

        await _emailRepository.AtualizarEmailAsync(emailEntity);

        return Result.Success(new AtualizarEmailResponse(emailEntity.EnderecoEmail));
    }
}
