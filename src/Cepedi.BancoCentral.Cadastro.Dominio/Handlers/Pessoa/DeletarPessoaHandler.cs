using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class DeletarPessoaHandler : IRequestHandler<DeletarPessoaRequest, Result<DeletarPessoaResponse>>
{
    private readonly ILogger<DeletarPessoaHandler> _logger;
    private readonly IPessoaRepository _pessoaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletarPessoaHandler(IPessoaRepository pessoaRepository, ILogger<DeletarPessoaHandler> logger, IUnitOfWork unitOfWork)
    {
        _pessoaRepository = pessoaRepository;
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<DeletarPessoaResponse>> Handle(DeletarPessoaRequest request, CancellationToken cancellationToken)
    {
        var pessoa = await _pessoaRepository.ObterPessoaAsync(request.Id);

        if (pessoa == null)
        {
            return Result.Error<DeletarPessoaResponse>(new Compartilhado.
                Excecoes.SemResultadosExcecao());
        }

        await _pessoaRepository.DeletarPessoaAsync(pessoa);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success(new DeletarPessoaResponse(pessoa.IdPessoa, pessoa.Nome));
    }
}
