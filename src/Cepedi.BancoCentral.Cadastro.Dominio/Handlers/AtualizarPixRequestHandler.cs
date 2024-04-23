using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class AtualizarPixRequestHandler
    : IRequestHandler<AtualizarPixRequest, Result<AtualizarPixResponse>>
{
    private readonly ILogger<AtualizarPixRequestHandler> _logger;
    private readonly IPixRepository _pixRepository;

    public AtualizarPixRequestHandler(IPixRepository pixRepository, ILogger<AtualizarPixRequestHandler> logger)
    {
        _pixRepository = pixRepository;
        _logger = logger;
    }

    public async Task<Result<AtualizarPixResponse>> Handle(AtualizarPixRequest request, CancellationToken cancellationToken){
        try
        {
            var pixEntity = await _pixRepository.ObterPixAsync(request.IdPix);

            if(pixEntity == null){
                return Result.Error<AtualizarPixResponse>(new Compartilhado.
                    Excecoes.SemResultadosExcecao());
            }
            
            pixEntity.Atualizar(pixEntity.ChavePix);

            await _pixRepository.AtualizarPixAsync(pixEntity);
            return Result.Success(new AtualizarPixResponse(pixEntity.ChavePix));
        }
        catch (System.Exception)
        {
             _logger.LogError("Ocorreu um erro ao atualizar os usuários");
            throw;
        }
    }
}
