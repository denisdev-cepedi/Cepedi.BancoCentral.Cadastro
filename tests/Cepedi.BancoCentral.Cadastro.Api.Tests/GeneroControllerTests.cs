using Cepedi.BancoCentral.Cadastro.Api.Controllers;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using NSubstitute;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Api.Tests;

public class GeneroControllerTests
{
    private readonly IMediator _mediator = Substitute.For<IMediator>();
    private readonly ILogger<GeneroController> _logger = Substitute.For<ILogger<GeneroController>>();
    private readonly GeneroController _sut;

    public GeneroControllerTests()
    {
        _sut = new GeneroController(_logger, _mediator);
    }

    [Fact]
    public async Task CriarGenero_DeveEnviarRequest_Para_Mediator()
    {
        // Arrange 
        var request = new CriarGeneroRequest { Descricao = "Masculino" };
        _mediator.Send(request).ReturnsForAnyArgs(Result.Success(new CriarGeneroResponse("Masculino")));

        // Act
        await _sut.CriarGeneroAsync(request);

        // Assert
        await _mediator.ReceivedWithAnyArgs().Send(request);
    }

    [Fact]
    public async Task AtualizarGenero_DeveEnviarRequest_Para_Mediator()
    {
        // Arrange 
        var request = new AtualizarGeneroRequest { Id = 1, Descricao = "Masculino" };
        _mediator.Send(request).ReturnsForAnyArgs(Result.Success(new AtualizarGeneroResponse("Masculino")));

        // Act
        await _sut.AtualizarGeneroAsync(request);

        // Assert
        await _mediator.ReceivedWithAnyArgs().Send(request);
    }

    [Fact]
    public async Task ExcluirGenero_DeveEnviarRequest_Para_Mediator()
    {
        // Arrange 
        var request = new DeletarGeneroRequest { Id = 1 };
        _mediator.Send(request).ReturnsForAnyArgs(Result.Success(new DeletarGeneroResponse("Masculino")));

        // Act
        await _sut.DeletarGeneroAsync(request);

        // Assert
        await _mediator.ReceivedWithAnyArgs().Send(request);
    }    
}
