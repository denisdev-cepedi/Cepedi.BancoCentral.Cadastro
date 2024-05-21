using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Handlers;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using OperationResult;
using Xunit; // Ensure you have the Xunit using directive if not already included

namespace Cepedi.BancoCentral.Cadastro.Dominio.Tests;

public class GetEmailsHandlerTests
{
    private readonly IEmailRepository _emailRepository = Substitute.For<IEmailRepository>();
    private readonly ILogger<GetEmailsHandler> _logger = Substitute.For<ILogger<GetEmailsHandler>>();
    private readonly GetEmailsHandler _sut;

    public GetEmailsHandlerTests()
    {
        _sut = new GetEmailsHandler(_emailRepository, _logger);
    }

    [Fact]
    public async Task GetEmailsAsync_QuandoObter_DeveRetornarSucesso()
    {
        // Arrange
        var emailRequest = new GetEmailsRequest();
        var emailEntities = new List<EmailEntity>
        {
            new EmailEntity { EnderecoEmail = "test@example.com" }
        };
        _emailRepository.GetEmailsAsync().ReturnsForAnyArgs(emailEntities);

        // Act
        var result = await _sut.Handle(emailRequest, CancellationToken.None);

        // Assert
        result.Should().BeOfType<Result<List<GetEmailsResponse>>>().Which
            .Value.Should().NotBeEmpty();
    }
}
