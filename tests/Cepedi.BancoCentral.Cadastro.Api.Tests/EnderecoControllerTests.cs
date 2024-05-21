using Cepedi.BancoCentral.Cadastro.Api.Controllers;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using NSubstitute;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Api.Tests;

public class EnderecoControllerTests
{
    private readonly IMediator _mediator = Substitute.For<IMediator>();
    private readonly ILogger<EnderecoController> _logger = Substitute.For<ILogger<EnderecoController>>();
    private readonly EnderecoController _sut;

    public EnderecoControllerTests()
    {
        _sut = new EnderecoController(_logger, _mediator);
    }

    [Fact]
    public async Task CriarEndereco_DeveEnviarRequest_Para_Mediator()
    {
        // Arrange 
        var request = new CriarEnderecoRequest { Cep = "12345678" };
        _mediator.Send(request).ReturnsForAnyArgs(Result.Success(new CriarEnderecoResponse("", "", "", "", "", "", "")));

        // Act
        await _sut.CriarEnderecoAsync(request);

        // Assert
        await _mediator.ReceivedWithAnyArgs().Send(request);
    }

    [Fact]
    public async Task AtualizarEndereco_DeveEnviarRequest_Para_Mediator()
    {
        // Arrange 
        var request = new AtualizarEnderecoRequest { IdEndereco = 1, Cep = "" };
        _mediator.Send(request)
            .ReturnsForAnyArgs(Result.Success(new AtualizarEnderecoResponse("", "", "", "", "", "", "")));

        // Act
        await _sut.AtualizarEnderecoAsync(request);

        // Assert
        await _mediator.ReceivedWithAnyArgs().Send(request);
    }

    [Fact]
    public async Task ExcluirEndereco_DeveEnviarRequest_Para_Mediator()
    {
        // Arrange 
        var request = new DeletarEnderecoRequest { Id = 1 };
        _mediator.Send(request).ReturnsForAnyArgs(Result.Success(new DeletarEnderecoResponse("")));

        // Act
        await _sut.DeletarEnderecoAsync(request);
    }
}
