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

    private readonly IPessoaRepository _pessoaRepository;
    private readonly IBancoRepository _bancoRepository;

    private readonly IUnitOfWork _unitOfWork;




    public CriarRegistroTransacaoBancoRequestHandler(ILogger<CriarRegistroTransacaoBancoRequestHandler> logger, 
    IRegistroTransacaoBancoRepository registroTransacaoBancoRepository, 
    ITipoRegistroRepository tipoRegistroRepository,
    IPessoaRepository pessoaRepository,
    IBancoRepository bancoRepository,
    IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _registroTransacaoBancoRepository = registroTransacaoBancoRepository;
        _tipoRegistroRepository = tipoRegistroRepository;
        _pessoaRepository = pessoaRepository;
        _bancoRepository = bancoRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<CriarRegistroTransacaoBancoResponse>> Handle(CriarRegistroTransacaoBancoRequest request, CancellationToken cancellationToken)
    {
        
        var pessoa = await _pessoaRepository.ObterPessoaAsync(request.IdPessoa);

        var banco = await _bancoRepository.ObterBancoAsync(request.IdBanco);

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
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(new CriarRegistroTransacaoBancoResponse(registroTransacao.IdRegistro, registroTransacao.DataRegistro, registroTransacao.TipoRegistro.NomeTipo, pessoa.Nome, banco.NomeReal));

    }
}
