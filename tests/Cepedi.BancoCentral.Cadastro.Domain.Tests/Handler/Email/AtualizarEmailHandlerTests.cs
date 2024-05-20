using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Handlers;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using NSubstitute;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Tests;

public class AtualizarEmailHandlerTests
{
    private readonly IEmailRepository _emailRepository =
    Substitute.For<IEmailRepository>();
    private readonly ILogger<AtualizarEmailHandler> _logger = Substitute.For<ILogger<AtualizarEmailHandler>>();
    private readonly AtualizarEmailHandler _sut;

    public AtualizarEmailHandlerTests()
    {
        _sut = new AtualizarEmailHandler(_emailRepository, _logger);
    }

    [Fact]
    public async Task AtualizarEmailAsync_QuandoAtualizar_DeveRetornarSucesso()
    {
        //Arrange 
        var email = new AtualizarEmailRequest { Email = "Alberto@teste.com" };
        var emailEntity = new EmailEntity { EnderecoEmail = "Alberto@teste.com" };
        _emailRepository.ObterEmailAsync(It.IsAny<int>()).ReturnsForAnyArgs(new EmailEntity());
        _emailRepository.AtualizarEmailAsync(It.IsAny<EmailEntity>())
            .ReturnsForAnyArgs(emailEntity);

        //Act
        var result = await _sut.Handle(email, CancellationToken.None);

        //Assert
        result.Should().BeOfType<Result<AtualizarEmailResponse>>().Which
            .Value.EnderecoEmail.Should().Be(email.Email);
        result.Should().BeOfType<Result<AtualizarEmailResponse>>().Which
            .Value.EnderecoEmail.Should().NotBeEmpty();
    }
}
