using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Shareable.Requests;
using Cepedi.BancoCentral.Cadastro.Shareable.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class AtualizarBancoRequestHandler : IRequestHandler<AtualizarBancoRequest, Result<AtualizarBancoResponse>>
{
    private readonly ILogger<AtualizarBancoRequestHandler> _logger;
    private readonly IBancoRepository _bancoRepository;
    
    public AtualizarBancoRequestHandler(IBancoRepository bancoRepository, ILogger<AtualizarBancoRequestHandler> logger)
    {
        _logger = logger;
        _bancoRepository = bancoRepository;
    }
    
    public Task<Result<AtualizarBancoResponse>> Handle(AtualizarBancoRequest request, CancellationToken cancellationToken)
    {
        var banco = new BancoEntity
        {
            IdBanco = request.IdBanco,
            NomeFantasia = request.NomeFantasia,
            NomeReal = request.NomeReal,
            Cnpj = request.Cnpj,
            DataCriacao = request.DataCriacao
        };
        
        _bancoRepository.AtualizarBancoAsync(banco);
        return Task.FromResult(Result.Success(new AtualizarBancoResponse(banco.IdBanco, banco.NomeFantasia, banco.NomeReal, banco.Cnpj, banco.DataCriacao)));
    }
}
