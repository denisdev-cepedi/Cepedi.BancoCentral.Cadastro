using Cepedi.BancoCentral.Cadastro.Api.Controllers;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using NSubstitute;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Api.Tests;

public class NacionalidadeControllerTests
{
    private readonly IMediator _mediator = Substitute.For<IMediator>();
    private readonly ILogger<NacionalidadeController> _logger = Substitute.For<ILogger<NacionalidadeController>>();
    private readonly NacionalidadeController _sut;

    public NacionalidadeControllerTests()
    {
        _sut = new NacionalidadeController(_logger, _mediator);
    }

    [Fact]
    public async Task CriarNacionalidade_DeveEnviarRequest_Para_Mediator()
    {
        // Arrange 
        var request = new CriarNacionalidadeRequest { Descricao = "Brasileiro" };
        _mediator.Send(request).ReturnsForAnyArgs(Result.Success(new CriarNacionalidadeResponse("Brasileiro")));

        // Act
        await _sut.CriarNacionalidadeAsync(request);

        // Assert
        await _mediator.ReceivedWithAnyArgs().Send(request);
    }

    [Fact]
    public async Task AtualizarNacionalidade_DeveEnviarRequest_Para_Mediator()
    {
        // Arrange 
        var request = new AtualizarNacionalidadeRequest { Id = 1, Descricao = "Brasileiro" };
        _mediator.Send(request).ReturnsForAnyArgs(Result.Success(new AtualizarNacionalidadeResponse("Brasileiro")));

        // Act
        await _sut.AtualizarNacionalidadeAsync(request);

        // Assert
        await _mediator.ReceivedWithAnyArgs().Send(request);
    }

    [Fact]
    public async Task ExcluirNacionalidade_DeveEnviarRequest_Para_Mediator()
    {
        // Arrange 
        var request = new DeletarNacionalidadeRequest { Id = 1 };
        _mediator.Send(request).ReturnsForAnyArgs(Result.Success(new DeletarNacionalidadeResponse("Brasileiro")));

        // Act
        await _sut.DeletarNacionalidadeAsync(request);
    }    
}
