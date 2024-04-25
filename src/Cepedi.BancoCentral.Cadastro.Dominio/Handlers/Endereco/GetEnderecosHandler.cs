using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class GetEnderecosHandler : IRequestHandler<GetEnderecosRequest, Result<List<GetEnderecosResponse>>>
{
    private readonly ILogger<GetEnderecosHandler> _logger;
    private readonly IEnderecoRepository _enderecoRepository;

    public GetEnderecosHandler(IEnderecoRepository enderecoRepository, ILogger<GetEnderecosHandler> logger)
    {
        _enderecoRepository = enderecoRepository;
        _logger = logger;
    }

    public async Task<Result<List<GetEnderecosResponse>>> Handle(GetEnderecosRequest request,
        CancellationToken cancellationToken)
    {
        var enderecos = await _enderecoRepository.GetEnderecosAsync();
        return Result.Success(enderecos.Select(e => new GetEnderecosResponse(e.Cep, e.Logradouro, e.Bairro, e.Cidade, e.Estado, e.Numero, e.Pais)).ToList());
    }
}
