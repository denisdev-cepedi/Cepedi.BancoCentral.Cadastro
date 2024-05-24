using System.Runtime.CompilerServices;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio;

public class DeletarRegistroTransacaoBancoRequestHandler : IRequestHandler<DeletarRegistroTransacaoBancoRequest, Result<DeletarRegistroTransacaoBancoResponse>>
{
    private readonly ILogger<DeletarRegistroTransacaoBancoRequestHandler> _logger;
    private readonly IRegistroTransacaoBancoRepository _registroTransacaoBancoRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeletarRegistroTransacaoBancoRequestHandler(ILogger<DeletarRegistroTransacaoBancoRequestHandler> logger, 
    IRegistroTransacaoBancoRepository registroTransacaoBancoRepository,
    IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _registroTransacaoBancoRepository = registroTransacaoBancoRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<DeletarRegistroTransacaoBancoResponse>> Handle(DeletarRegistroTransacaoBancoRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Deletando registro {request.IdRegistro} de transação de banco , data: {DateTime.Now}");
        var registroEncontrado = await _registroTransacaoBancoRepository.ObterRegistroTransacaoBancoAsync(request.IdRegistro);
        await _registroTransacaoBancoRepository.DeletarRegistroTransacaoBancoAsync(registroEncontrado);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(new DeletarRegistroTransacaoBancoResponse(request.IdRegistro, request.Motivo));
    }
}
