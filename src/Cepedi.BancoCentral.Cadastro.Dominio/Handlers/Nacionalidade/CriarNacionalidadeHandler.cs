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

    public CriarNacionalidadeHandler(INacionalidadeRepository nacionalidadeRepository, ILogger<CriarNacionalidadeHandler> logger)
    {
        _nacionalidadeRepository = nacionalidadeRepository;
        _logger = logger;
    }

    public async Task<Result<CriarNacionalidadeResponse>> Handle(CriarNacionalidadeRequest request, CancellationToken cancellationToken)
    {
        var nacionalidade = new NacionalidadeEntity()
        {
            NomeNacionalidade = request.Descricao
        };

        await _nacionalidadeRepository.CriarNacionalidadeAsync(nacionalidade);

        return Result.Success(new CriarNacionalidadeResponse(nacionalidade.NomeNacionalidade));
    }
}
