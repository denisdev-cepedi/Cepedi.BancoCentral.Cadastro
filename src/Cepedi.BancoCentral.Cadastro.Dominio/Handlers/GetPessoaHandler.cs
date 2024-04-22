using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class GetPessoaHandler : IRequestHandler<GetPessoasRequest, Result<List<GetPessoasResponse>>>
{
    private readonly ILogger<GetPessoaHandler> _logger;
    private readonly IPessoaRepository _pessoaRepository;

    public GetPessoaHandler(IPessoaRepository pessoaRepository, ILogger<GetPessoaHandler> logger)
    {
        _pessoaRepository = pessoaRepository;
        _logger = logger;
    }

    public async Task<Result<List<GetPessoasResponse>>> Handle(GetPessoasRequest request,
        CancellationToken cancellationToken)
    {
        var pessoas = await _pessoaRepository.GetPessoasAsync();
        return Result.Success(pessoas.Select(p => new GetPessoasResponse(p.IdPessoa, p.Nome)).ToList());
    }
}
