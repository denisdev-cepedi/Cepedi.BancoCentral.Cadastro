using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class CriarPixHandler : IRequestHandler<CriarPixRequest, Result<CriarPixResponse>>
{
    private readonly ILogger<CriarPixHandler> _logger;
    private readonly IPixRepository _pixRepository;

    public CriarPixHandler(IPixRepository pixRepository, ILogger<CriarPixHandler> logger)
    {
        _pixRepository = pixRepository;
        _logger = logger;
    }

    public async Task<Result<CriarPixResponse>> Handle(CriarPixRequest request, CancellationToken cancellationToken)
    {
         _logger.LogInformation("Iniciando a criação do Pix.");
        var pix = new PixEntity()
        {
            IdPessoa = request.IdCliente,
            ChavePix = request.ChavePix,
            TipoPix = request.TipoPix,
        };

        await _pixRepository.CriarPixAsync(pix);

        return Result.Success(new CriarPixResponse(pix.ChavePix, pix.TipoPix));
    }
}
