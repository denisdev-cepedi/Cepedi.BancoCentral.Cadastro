using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class GetPixHandler
    : IRequestHandler<GetPixRequest, Result<List<GetPixResponse>>>
{
    private readonly ILogger<GetPixHandler> _logger;
    private readonly IPixRepository _pixRepository;

    public GetPixHandler(IPixRepository pixRepository, ILogger<GetPixHandler> logger)
    {
        _pixRepository = pixRepository;
        _logger = logger;
    }

    public async Task<Result<List<GetPixResponse>>> Handle(GetPixRequest request, CancellationToken cancellationToken)
    {
        var pix = await _pixRepository.GetPixsAync();
        return Result.Success(pix.Select(p => new GetPixResponse(p.IdPix, p.ChavePix)).ToList());
    }

}
