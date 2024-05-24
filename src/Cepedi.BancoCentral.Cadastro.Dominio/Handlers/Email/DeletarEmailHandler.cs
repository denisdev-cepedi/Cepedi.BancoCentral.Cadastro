using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class DeletarEmailHandler : IRequestHandler<DeletarEmailRequest, Result<DeletarEmailResponse>>
{
    private readonly ILogger<DeletarEmailHandler> _logger;
    private readonly IEmailRepository _emailRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletarEmailHandler(IEmailRepository emailRepository, ILogger<DeletarEmailHandler> logger, IUnitOfWork unitOfWork)
    {
        _emailRepository = emailRepository;
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<DeletarEmailResponse>> Handle(DeletarEmailRequest request, CancellationToken cancellationToken)
    {
        var email = await _emailRepository.ObterEmailAsync(request.Id);

        if (email == null)
        {
            return Result.Error<DeletarEmailResponse>(new Compartilhado.
                Excecoes.SemResultadosExcecao());
        }

        await _emailRepository.DeletarEmailAsync(email);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success(new DeletarEmailResponse(email.EnderecoEmail));
    }
}
