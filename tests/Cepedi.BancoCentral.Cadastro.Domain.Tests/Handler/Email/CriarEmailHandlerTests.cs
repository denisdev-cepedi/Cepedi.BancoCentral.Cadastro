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

public class CriarEmailHandlerTests
{
    private readonly IEmailRepository _emailRepository = Substitute.For<IEmailRepository>();
    private readonly ILogger<CriarEmailHandler> _logger = Substitute.For<ILogger<CriarEmailHandler>>();
    private readonly CriarEmailHandler _sut;
    
    public CriarEmailHandlerTests()
    {
        _sut = new CriarEmailHandler(_emailRepository, _logger);
    }

    [Fact]
    public async Task CriarEmailAsync_QuandoCriar_DeveRetornarSucesso()
    {
        //Arrange 
        var email = new CriarEmailRequest { EnderecoEmail = "Alberto@teste.com", IdPessoa = 0};
        _emailRepository.CriarEmailAsync(It.IsAny<EmailEntity>())
            .ReturnsForAnyArgs(new EmailEntity());

        //Act
        var result = await _sut.Handle(email, CancellationToken.None);

        //Assert
        result.Should().BeOfType<Result<CriarEmailResponse>>().Which
            .Value.EnderecoEmail.Should().Be(email.EnderecoEmail, "O email deve ser o mesmo que foi passado");
        result.Should().BeOfType<Result<CriarEmailResponse>>().Which
            .Value.EnderecoEmail.Should().NotBeEmpty();
    }
}
