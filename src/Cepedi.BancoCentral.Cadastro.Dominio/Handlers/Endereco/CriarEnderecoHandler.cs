using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class CriarEnderecoHandler : IRequestHandler<CriarEnderecoRequest, Result<CriarEnderecoResponse>>
{
    private readonly ILogger<CriarEnderecoHandler> _logger;
    private readonly IEnderecoRepository _enderecoRepository;

    public CriarEnderecoHandler(IEnderecoRepository enderecoRepository, ILogger<CriarEnderecoHandler> logger)
    {
        _enderecoRepository = enderecoRepository;
        _logger = logger;
    }

    public async Task<Result<CriarEnderecoResponse>> Handle(CriarEnderecoRequest request, CancellationToken cancellationToken)
    {
        var endereco = new EnderecoEntity()
        {
            IdPessoa = request.IdPessoa,
            Logradouro = request.Logradouro,
            Numero = request.Numero,
            Bairro = request.Bairro,
            Cidade = request.Cidade,
            Estado = request.Estado,
            Pais = request.Pais,
            Cep = request.Cep
        };

        await _enderecoRepository.CriarEnderecoAsync(endereco);

        return Result.Success(new CriarEnderecoResponse(endereco.Cep, endereco.Logradouro, endereco.Bairro, endereco.Cidade, endereco.Estado, endereco.Numero, endereco.Pais));
    }
}
