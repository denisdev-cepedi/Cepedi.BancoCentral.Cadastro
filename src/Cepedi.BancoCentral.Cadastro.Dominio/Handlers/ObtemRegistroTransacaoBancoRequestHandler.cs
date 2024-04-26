using System.Runtime.CompilerServices;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio;

public class ObtemRegistroTransacaoBancoRequestHandler : IRequestHandler<ObtemRegistroTransacaoBancoRequest, Result<ObtemRegistroTransacaoBancoResponse>>
{
    private readonly ILogger<ObtemRegistroTransacaoBancoRequestHandler> _logger;
    private readonly IRegistroTransacaoBancoRepository _registroTransacaoBancoRepository;
    public ObtemRegistroTransacaoBancoRequestHandler(ILogger<ObtemRegistroTransacaoBancoRequestHandler> logger, IRegistroTransacaoBancoRepository registroTransacaoBancoRepository)
    {
        _logger = logger;
        _registroTransacaoBancoRepository = registroTransacaoBancoRepository;
    }

    public async Task<Result<ObtemRegistroTransacaoBancoResponse>> Handle(ObtemRegistroTransacaoBancoRequest request, CancellationToken cancellationToken)
    {
        var registroTransacao = await _registroTransacaoBancoRepository.ObterRegistroTransacaoBancoAsync(request.IdRegistro);
        if (registroTransacao == null)
        {
            return Result.Error<ObtemRegistroTransacaoBancoResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(
                (Compartilhado.Enums.Cadastro.SemResultados)));
        }
        return Result.Success(new ObtemRegistroTransacaoBancoResponse(registroTransacao.IdRegistro, registroTransacao.DataRegistro, registroTransacao.TipoRegistro.NomeTipo, registroTransacao.Pessoa.Nome, registroTransacao.Banco.NomeReal));
    }
}
