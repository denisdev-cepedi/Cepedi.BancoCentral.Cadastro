using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class DeletarEnderecoHandler : IRequestHandler<DeletarEnderecoRequest, Result<DeletarEnderecoResponse>>
{
    private readonly ILogger<DeletarEnderecoHandler> _logger;
    private readonly IEnderecoRepository _enderecoRepository;

    public DeletarEnderecoHandler(IEnderecoRepository enderecoRepository, ILogger<DeletarEnderecoHandler> logger)
    {
        _enderecoRepository = enderecoRepository;
        _logger = logger;
    }

    public async Task<Result<DeletarEnderecoResponse>> Handle(DeletarEnderecoRequest request, CancellationToken cancellationToken)
    {
        var endereco = await _enderecoRepository.ObterEnderecoAsync(request.Id);

        if (endereco == null)
        {
            return Result.Error<DeletarEnderecoResponse>(new Compartilhado.
                Excecoes.SemResultadosExcecao());
        }

        await _enderecoRepository.DeletarEnderecoAsync(endereco);

        return Result.Success(new DeletarEnderecoResponse(endereco.Logradouro));
    }
}
