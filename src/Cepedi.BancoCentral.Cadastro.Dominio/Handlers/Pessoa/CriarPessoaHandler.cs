using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;
public class CriarPessoaHandler
    : IRequestHandler<CriarPessoaRequest, Result<CriarPessoaResponse>>
{
    private readonly ILogger<CriarPessoaHandler> _logger;
    private readonly IPessoaRepository _pessoaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CriarPessoaHandler(IPessoaRepository pessoaRepository, ILogger<CriarPessoaHandler> logger, IUnitOfWork unitOfWork)
    {
        _pessoaRepository = pessoaRepository;
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<CriarPessoaResponse>> Handle(CriarPessoaRequest request, CancellationToken cancellationToken)
    {
        var pessoa = new PessoaEntity()
        {
            Nome = request.Nome,
            DataNascimento = request.DataNascimento,
            Cpf = request.Cpf,
            Genero = request.Genero,
            EstadoCivil = request.EstadoCivil,
            Nacionalidade = request.Nacionalidade
        };

        await _pessoaRepository.CriarPessoaAsync(pessoa);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success(new CriarPessoaResponse(pessoa.IdPessoa, pessoa.Nome));
    }
}
