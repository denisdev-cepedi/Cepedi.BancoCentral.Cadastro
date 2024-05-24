using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Handlers;

public class CriarNacionalidadeHandler : IRequestHandler<CriarNacionalidadeRequest, Result<CriarNacionalidadeResponse>>
{
    private readonly ILogger<CriarNacionalidadeHandler> _logger;
    private readonly INacionalidadeRepository _nacionalidadeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CriarNacionalidadeHandler(INacionalidadeRepository nacionalidadeRepository, ILogger<CriarNacionalidadeHandler> logger, IUnitOfWork unitOfWork)
    {
        _nacionalidadeRepository = nacionalidadeRepository;
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<CriarNacionalidadeResponse>> Handle(CriarNacionalidadeRequest request, CancellationToken cancellationToken)
    {
        var nacionalidade = new NacionalidadeEntity()
        {
            NomeNacionalidade = request.Descricao
        };

        await _nacionalidadeRepository.CriarNacionalidadeAsync(nacionalidade);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success(new CriarNacionalidadeResponse(nacionalidade.NomeNacionalidade));
    }
}
