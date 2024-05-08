using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;
public class AtualizarPessoaRequestHandler :
    IRequestHandler<AtualizarPessoaRequest, Result<AtualizarPessoaResponse>>
{
    private readonly IPessoaRepository _pessoaRepository;
    private readonly ILogger<AtualizarPessoaRequestHandler> _logger;

    public AtualizarPessoaRequestHandler(IPessoaRepository pessoaRepository, ILogger<AtualizarPessoaRequestHandler> logger)
    {
        _pessoaRepository = pessoaRepository;
        _logger = logger;
    }

    public async Task<Result<AtualizarPessoaResponse>> Handle(AtualizarPessoaRequest request, CancellationToken cancellationToken)
    {
        var pessoaEntity = await _pessoaRepository.ObterPessoaAsync(request.IdPessoa);

        if (pessoaEntity == null)
        {
            return Result.Error<AtualizarPessoaResponse>(new Compartilhado.
                Excecoes.SemResultadosExcecao());
        }

        pessoaEntity.Atualizar(request.Nome);

        await _pessoaRepository.AtualizarPessoaAsync(pessoaEntity);

        return Result.Success(new AtualizarPessoaResponse(pessoaEntity.Nome));
    }
}
