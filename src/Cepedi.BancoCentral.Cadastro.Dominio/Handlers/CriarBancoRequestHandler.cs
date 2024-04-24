using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Shareable.Requests;
using Cepedi.BancoCentral.Cadastro.Shareable.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class CriarBancoRequestHandler : IRequestHandler<CriarBancoRequest, Result<CriarBancoResponse>>
{
    private readonly ILogger<CriarBancoRequestHandler> _logger;
    private readonly IBancoRepository _bancoRepository;

    public CriarBancoRequestHandler(IBancoRepository bancoRepository, ILogger<CriarBancoRequestHandler> logger)
    {
        _logger = logger;
        _bancoRepository = bancoRepository;
    }

    public async Task<Result<CriarBancoResponse>> Handle(CriarBancoRequest request, CancellationToken cancellationToken)
    {
        var banco = new BancoEntity
        {
            NomeReal = request.NomeFantasia, Cnpj = request.Cnpj, DataCriacao = request.DataCriacao
        };
        await _bancoRepository.CriarBancoAsync(banco);
        return Result.Success(new CriarBancoResponse(banco.IdBanco, banco.NomeReal, banco.Cnpj, banco.DataCriacao));
    }
}
