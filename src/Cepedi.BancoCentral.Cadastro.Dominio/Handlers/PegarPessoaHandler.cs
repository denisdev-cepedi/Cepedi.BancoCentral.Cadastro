using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class PegarPessoaHandler : IRequestHandler<PegarPessoasRequest, Result<List<PegarPessoasResponse>>>
{
    private readonly ILogger<PegarPessoaHandler> _logger;
    private readonly IPessoaRepository _pessoaRepository;

    public PegarPessoaHandler(IPessoaRepository pessoaRepository, ILogger<PegarPessoaHandler> logger)
    {
        _pessoaRepository = pessoaRepository;
        _logger = logger;
    }

    public async Task<Result<List<PegarPessoasResponse>>> Handle(PegarPessoasRequest request,
        CancellationToken cancellationToken)
    {
        var pessoas = await _pessoaRepository.GetPessoasAsync();
        return Result.Success(pessoas.Select(p => new PegarPessoasResponse(p.IdPessoa, p.Nome)).ToList());
    }
}
