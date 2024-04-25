using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class AtualizarEnderecoHandler : IRequestHandler<AtualizarEnderecoRequest, Result<AtualizarEnderecoResponse>>
{
    private readonly IEnderecoRepository _enderecoRepository;
    private readonly ILogger<AtualizarEnderecoHandler> _logger;

    public AtualizarEnderecoHandler(IEnderecoRepository enderecoRepository, ILogger<AtualizarEnderecoHandler> logger)
    {
        _enderecoRepository = enderecoRepository;
        _logger = logger;
    }

    public async Task<Result<AtualizarEnderecoResponse>> Handle(AtualizarEnderecoRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var enderecoEntity = await _enderecoRepository.ObterEnderecoAsync(request.IdEndereco);

            if (enderecoEntity == null)
            {
                return Result.Error<AtualizarEnderecoResponse>(new Compartilhado.Excecoes.SemResultadosExcecao());
            }

            enderecoEntity.Atualizar(request.Cep, request.Logradouro, request.Bairro, request.Cidade, request.Estado, request.Numero, request.Pais);

            await _enderecoRepository.AtualizarEnderecoAsync(enderecoEntity);

            return Result.Success(new AtualizarEnderecoResponse(enderecoEntity.Cep, enderecoEntity.Logradouro,
                enderecoEntity.Bairro, enderecoEntity.Cidade, enderecoEntity.Estado, enderecoEntity.Numero,
                enderecoEntity.Pais));
        }
        catch
        {
            _logger.LogError("Ocorreu um erro ao atualizar os enderecos");
            throw;
        }
    }
}
