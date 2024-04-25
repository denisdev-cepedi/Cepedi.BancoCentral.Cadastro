using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class DeletarPixHandler : IRequestHandler<DeletarPixRequest, Result<DeletarPixResponse>>
{
    private readonly ILogger<DeletarPixHandler> _logger;
    private readonly IPixRepository _pixRepository;

    public DeletarPixHandler(IPixRepository pixRepository, ILogger<DeletarPixHandler> logger)
    {
        _pixRepository = pixRepository;
        _logger = logger;
    }

    public async Task<Result<DeletarPixResponse>> Handle(DeletarPixRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var pix = await _pixRepository.ObterPixAsync(request.IdPix);

            if (pix == null)
            {
                return Result.Error<DeletarPixResponse>(new Compartilhado.
                    Excecoes.SemResultadosExcecao());
            }

            await _pixRepository.DeletarPixAsync(pix.IdPix);

            return Result.Success(new DeletarPixResponse(pix.ChavePix));
        }
        catch
        {
            _logger.LogError("Ocorreu um erro durante a execução");
            return Result.Error<DeletarPixResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(
                (Compartilhado.Enums.Cadastro.ErroGravacaoUsuario)));
        }
    }
}
