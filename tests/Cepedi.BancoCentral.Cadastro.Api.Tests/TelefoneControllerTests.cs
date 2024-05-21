using Cepedi.BancoCentral.Cadastro.Api.Controllers;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using NSubstitute;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Api.Tests;

public class TelefoneControllerTests
{
    private readonly IMediator _mediator = Substitute.For<IMediator>();
    private readonly ILogger<TelefoneController> _logger = Substitute.For<ILogger<TelefoneController>>();
    private readonly TelefoneController _sut;

    public TelefoneControllerTests()
    {
        _sut = new TelefoneController(_logger, _mediator);
    }

    [Fact]
    public async Task CriarTelefone_DeveEnviarRequest_Para_Mediator()
    {
        // Arrange 
        var request = new CriarTelefoneRequest { IdPessoa = 1, NumeroTelefone = "999999999" };
        _mediator.Send(request).ReturnsForAnyArgs(Result.Success(new CriarTelefoneResponse("999999999")));

        // Act
        await _sut.CriarTelefoneAsync(request);

        // Assert
        await _mediator.ReceivedWithAnyArgs().Send(request);
    }

    [Fact]
    public async Task AtualizarTelefone_DeveEnviarRequest_Para_Mediator()
    {
        // Arrange 
        var request = new AtualizarTelefoneRequest { IdTelefone = 1, NumeroTelefone = "999999999" };
        _mediator.Send(request).ReturnsForAnyArgs(Result.Success(new AtualizarTelefoneResponse("999999999")));

        // Act
        await _sut.AtualizarTelefoneAsync(request);

        // Assert
        await _mediator.ReceivedWithAnyArgs().Send(request);
    }

    [Fact]
    public async Task ExcluirTelefone_DeveEnviarRequest_Para_Mediator()
    {
        // Arrange 
        var request = new DeletarTelefoneRequest { IdTelefone = 1 };
        _mediator.Send(request).ReturnsForAnyArgs(Result.Success(new DeletarTelefoneResponse("999999999")));

        // Act
        await _sut.DeletarTelefoneAsync(request);
    }    
}
