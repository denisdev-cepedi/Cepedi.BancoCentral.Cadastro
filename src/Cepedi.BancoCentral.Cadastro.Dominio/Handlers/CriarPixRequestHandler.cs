using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class CriarPixRequestHandler
    : IRequestHandler<CriarPixRequest, Result<CriarPixResponse>>
{
    private readonly ILogger<CriarPixRequestHandler> _logger;
    private readonly IPixRepository _pixRepository;

    public CriarPixRequestHandler(IPixRepository pixRepository, ILogger<CriarPixRequestHandler> logger)
    {
        _pixRepository = pixRepository;
        _logger = logger;
    }

    public async Task<Result<CriarPixResponse>> Handle(CriarPixRequest request, CancellationToken cancellationToken)
    {

        var pix = new PixEntity()
        {
            ChavePix = request.ChavePix,
            Agencia = request.Agencia,
            Conta = request.Conta,
            Instituicao = request.Instituicao,
            IdTipoPix = request.IdTipoPix
        };

        await _pixRepository.CriarPixAsync(pix);
        return Result.Success(new CriarPixResponse(pix.IdPix, pix.ChavePix));

    }
}
