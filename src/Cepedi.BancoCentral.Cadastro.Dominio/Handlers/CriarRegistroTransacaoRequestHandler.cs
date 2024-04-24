using System.Runtime.CompilerServices;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio;

public class CriarRegistroTransacaoBancoRequestHandler : IRequestHandler<CriarRegistroTransacaoBancoRequest, Result<CriarRegistroTransacaoBancoResponse>>
{
    private readonly ILogger<CriarRegistroTransacaoBancoRequestHandler> _logger;
    private readonly IRegistroTransacaoBancoRepository _registroTransacaoBancoRepository;
    private readonly ITipoRegistroRepository _tipoRegistroRepository;




    public CriarRegistroTransacaoBancoRequestHandler(ILogger<CriarRegistroTransacaoBancoRequestHandler> logger, IRegistroTransacaoBancoRepository registroTransacaoBancoRepository, ITipoRegistroRepository tipoRegistroRepository)
    {
        _logger = logger;
        _registroTransacaoBancoRepository = registroTransacaoBancoRepository;
        _tipoRegistroRepository = tipoRegistroRepository;
    }

    public async Task<Result<CriarRegistroTransacaoBancoResponse>> Handle(CriarRegistroTransacaoBancoRequest request, CancellationToken cancellationToken)
    {
        if (request.Valor <= 0)
        {
            throw new Exception("O valor da transação deve ser maior que zero");
        }
        //Todo : Fazer Busca da Pessoa pelo id, quando o método estiver pronto
        var pessoa = await _registroTransacaoBancoRepository.ObterRegistroTransacaoBancoPorIdPessoaAsync(request.IdPessoa);

        //Todo : Fazer Busca do Banco pelo id, quando o método estiver pronto
        var banco = await _registroTransacaoBancoRepository.ObterRegistroTransacaoBancoPorIdBancoAsync(request.IdBanco);

        var tipoRegistro = await _tipoRegistroRepository.ObterTipoRegistroAsync(request.IdTipoRegistro);

        var registroTransacao = new RegistroTransacaoBancoEntity()
        {
            DataRegistro = request.DataRegistro,
            Valor = request.Valor,
            Pessoa = pessoa,
            Banco = banco,
            TipoRegistro = tipoRegistro
        };

        await _registroTransacaoBancoRepository.CriarRegistroTransacaoBancoAsync(registroTransacao);

        return Result.Success(new CriarRegistroTransacaoBancoResponse(registroTransacao.IdRegistro, registroTransacao.DataRegistro, registroTransacao.TipoRegistro.NomeTipo, pessoa.Nome, banco.NomeReal));

    }
}
