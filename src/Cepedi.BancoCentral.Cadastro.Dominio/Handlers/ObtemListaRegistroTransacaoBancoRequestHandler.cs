using System.Runtime.CompilerServices;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio;

public class ObtemListaRegistroTransacaoBancoRequestHandler : IRequestHandler<ObtemListaRegistroTransacaoBancoRequest, Result<List<ObtemRegistroTransacaoBancoResponse>>>
{
    private readonly ILogger<ObtemListaRegistroTransacaoBancoRequestHandler> _logger;
    private readonly IRegistroTransacaoBancoRepository _registroTransacaoBancoRepository;
    public ObtemListaRegistroTransacaoBancoRequestHandler(ILogger<ObtemListaRegistroTransacaoBancoRequestHandler> logger, IRegistroTransacaoBancoRepository registroTransacaoBancoRepository)
    {
        _logger = logger;
        _registroTransacaoBancoRepository = registroTransacaoBancoRepository;
    }
    public async Task<Result<List<ObtemRegistroTransacaoBancoResponse>>> Handle(ObtemListaRegistroTransacaoBancoRequest request, CancellationToken cancellationToken)
    {
        var tipos = await _registroTransacaoBancoRepository.ObterRegistroTransacaoBancoAsync();
        
        // IdTransacao,DateTime DataRegistro, string NomeTipoRegistro, string NomePessoa, string NomeBanco
            return Result.Success(tipos.Select(t => new ObtemRegistroTransacaoBancoResponse(t.IdRegistro,t.DataRegistro, t.TipoRegistro.NomeTipo,t.Pessoa.Nome,t.Banco.NomeReal)).ToList());
    }
}
