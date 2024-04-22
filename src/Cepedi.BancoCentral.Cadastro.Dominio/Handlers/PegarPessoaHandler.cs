using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class PegarPessoaHandler : IRequestHandler<PegarPessoasRequest, Result<PegarPessoasResponse>>
{
    private readonly ILogger<PegarPessoaHandler> _logger;
    private readonly IPessoaRepository _pessoaRepository;

    public PegarPessoaHandler(IPessoaRepository pessoaRepository, ILogger<PegarPessoaHandler> logger)
    {
        _pessoaRepository = pessoaRepository;
        _logger = logger;
    }

    public async Task<Result<PegarPessoasResponse>> Handle(PegarPessoasRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var pessoas = await _pessoaRepository.GetPessoasAsync();

            return Result.Success(new PegarPessoasResponse());
        }
        catch
        {
            _logger.LogError("Ocorreu um erro durante a execução");
            return Result.Error<PegarPessoasResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(
                (Compartilhado.Enums.Cadastro.ErroGravacaoUsuario)));
        }
    }

}
