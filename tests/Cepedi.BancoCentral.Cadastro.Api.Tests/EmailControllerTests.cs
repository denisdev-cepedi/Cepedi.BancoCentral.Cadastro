using Cepedi.BancoCentral.Cadastro.Api.Controllers;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using NSubstitute;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Api.Tests;

public class EmailControllerTests
{
    private readonly IMediator _mediator = Substitute.For<IMediator>();
    private readonly ILogger<EmailController> _logger = Substitute.For<ILogger<EmailController>>();
    private readonly EmailController _sut;

    public EmailControllerTests()
    {
        _sut = new EmailController(_logger, _mediator);
    }

    [Fact]
    public async Task CriarEmail_DeveEnviarRequest_Para_Mediator()
    {
        // Arrange 
        var request = new CriarEmailRequest { EnderecoEmail = "Alberto@teste.com" };
        _mediator.Send(request).ReturnsForAnyArgs(Result.Success(new CriarEmailResponse(1, "")));

        // Act
        await _sut.CriarEmailAsync(request);

        // Assert
        await _mediator.ReceivedWithAnyArgs().Send(request);
    }

    [Fact]
    public async Task AtualizarEmail_DeveEnviarRequest_Para_Mediator()
    {
        // Arrange 
        var request = new AtualizarEmailRequest { Id = 1, Email = "" };
        _mediator.Send(request).ReturnsForAnyArgs(Result.Success(new AtualizarEmailResponse(1, "")));

        // Act
        await _sut.AtualizarEmailAsync(request);

        // Assert
        await _mediator.ReceivedWithAnyArgs().Send(request);
    }

    [Fact]
    public async Task ExcluirEmail_DeveEnviarRequest_Para_Mediator()
    {
        // Arrange 
        var request = new DeletarEmailRequest { Id = 1 };
        _mediator.Send(request).ReturnsForAnyArgs(Result.Success(new DeletarEmailResponse("")));

        // Act
        await _sut.DeletarEmailAsync(request);

        // Assert
        await _mediator.ReceivedWithAnyArgs().Send(request);
    }

    [Fact]
    public async Task GetEmails_DeveEnviarRequest_Para_Mediator()
    {
        // Arrange 
        var request = new GetEmailsRequest();
        _mediator.Send(request).ReturnsForAnyArgs(Result.Success(new List<GetEmailsResponse> { new GetEmailsResponse("") }));

        // Act
        await _sut.GetEmailAsync();

        // Assert
        await _mediator.ReceivedWithAnyArgs().Send(request);
    }

}
