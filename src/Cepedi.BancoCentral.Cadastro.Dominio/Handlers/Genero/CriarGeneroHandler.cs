using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class CriarGeneroHandler : IRequestHandler<CriarGeneroRequest, Result<CriarGeneroResponse>>
{
    private readonly ILogger<CriarGeneroHandler> _logger;
    private readonly IGeneroRepository _generoRepository;

    public CriarGeneroHandler(IGeneroRepository generoRepository, ILogger<CriarGeneroHandler> logger)
    {
        _generoRepository = generoRepository;
        _logger = logger;
    }

    public async Task<Result<CriarGeneroResponse>> Handle(CriarGeneroRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var genero = new GeneroEntity()
            {
                NomeGenero = request.Descricao
            };

            await _generoRepository.CriarGeneroAsync(genero);

            return Result.Success(new CriarGeneroResponse(genero.NomeGenero));
        }
        catch
        {
            _logger.LogError("Ocorreu um erro durante a execução");
            return Result.Error<CriarGeneroResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(
                (Compartilhado.Enums.Cadastro.ErroGravacaoUsuario)));
        }
    }
}
