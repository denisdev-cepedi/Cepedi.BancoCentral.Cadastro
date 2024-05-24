using Cepedi.BancoCentral.Cadastro.Api.Controllers;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using NSubstitute;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Api.Tests;

public class EstadoCivilControllerTests
{
    private readonly IMediator _mediator = Substitute.For<IMediator>();
    private readonly ILogger<EstadoCivilController> _logger = Substitute.For<ILogger<EstadoCivilController>>();
    private readonly EstadoCivilController _sut;

    public EstadoCivilControllerTests()
    {
        _sut = new EstadoCivilController(_logger, _mediator);
    }

    [Fact]
    public async Task CriarEstadoCivil_DeveEnviarRequest_Para_Mediator()
    {
        // Arrange 
        var request = new CriarEstadoCivilRequest { Descricao = "Solteiro" };
        _mediator.Send(request).ReturnsForAnyArgs(Result.Success(new CriarEstadoCivilResponse("Solteiro")));

        // Act
        await _sut.CriarEstadoCivilAsync(request);

        // Assert
        await _mediator.ReceivedWithAnyArgs().Send(request);
    }

    [Fact]
    public async Task AtualizarEstadoCivil_DeveEnviarRequest_Para_Mediator()
    {
        // Arrange 
        var request = new AtualizarEstadoCivilRequest { Id = 1, Descricao = "Solteiro" };
        _mediator.Send(request).ReturnsForAnyArgs(Result.Success(new AtualizarEstadoCivilResponse("Solteiro")));

        // Act
        await _sut.AtualizarEstadoCivilAsync(request);

        // Assert
        await _mediator.ReceivedWithAnyArgs().Send(request);
    }

    [Fact]
    public async Task ExcluirEstadoCivil_DeveEnviarRequest_Para_Mediator()
    {
        // Arrange 
        var request = new DeletarEstadoCivilRequest { Id = 1 };
        _mediator.Send(request).ReturnsForAnyArgs(Result.Success(new DeletarEstadoCivilResponse("Solteiro")));

        // Act
        await _sut.DeletarEstadoCivilAsync(request);

        // Assert
        await _mediator.ReceivedWithAnyArgs().Send(request);
    }
}
