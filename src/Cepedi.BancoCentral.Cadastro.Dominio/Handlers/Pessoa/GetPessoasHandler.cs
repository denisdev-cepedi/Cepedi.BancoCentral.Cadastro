using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class GetPessoasHandler : IRequestHandler<GetPessoasRequest, Result<List<GetPessoasResponse>>>
{
    private readonly ILogger<GetPessoasHandler> _logger;
    private readonly IPessoaRepository _pessoaRepository;

    public GetPessoasHandler(IPessoaRepository pessoaRepository, ILogger<GetPessoasHandler> logger)
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
