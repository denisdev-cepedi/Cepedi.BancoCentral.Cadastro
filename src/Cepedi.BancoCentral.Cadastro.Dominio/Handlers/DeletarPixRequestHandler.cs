using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class DeletarPixRequestHandler
    : IRequestHandler<DeletarPixRequest, Result<DeletarPixResponse>>
{
    private readonly ILogger<DeletarPixRequestHandler> _logger;
    private readonly IPixRepository _pixRepository;

    public DeletarPixRequestHandler(IPixRepository pixRepository, ILogger<DeletarPixRequestHandler> logger)
    {
        _pixRepository = pixRepository;
        _logger = logger;
    }

    public async Task<Result<DeletarPixResponse>> Handle(DeletarPixRequest request, CancellationToken cancellationToken)
    {
        var pix = await _pixRepository.ObterPixAsync(request.IdPix);

        if (pix == null)
        {
            return Result.Error<DeletarPixResponse>(new Compartilhado.
                Excecoes.SemResultadosExcecao());
        }

        await _pixRepository.DeletarPixAsync(pix);
        return Result.Success(new DeletarPixResponse(pix.IdPix, pix.ChavePix));
    }
}
