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

public class DeletarEmailHandlerTests
{
    private readonly IEmailRepository _emailRepository = Substitute.For<IEmailRepository>();
    private readonly ILogger<DeletarEmailHandler> _logger = Substitute.For<ILogger<DeletarEmailHandler>>();
    private readonly DeletarEmailHandler _sut;
    private readonly IUnitOfWork _unitOfWork = Substitute.For<IUnitOfWork>();

    public DeletarEmailHandlerTests()
    {
        _sut = new DeletarEmailHandler(_emailRepository, _logger, _unitOfWork);
    }

    [Fact]
    public async Task DeletarEmailAsync_QuandoDeletar_DeveRetornarSucesso()
    {
        //Arrange 
        var email = new DeletarEmailRequest { Id = 0 };
        _emailRepository.ObterEmailAsync(It.IsAny<int>())
            .ReturnsForAnyArgs(new EmailEntity());
        _emailRepository.DeletarEmailAsync(It.IsAny<EmailEntity>())
            .ReturnsForAnyArgs(new EmailEntity());

        //Act
        var result = await _sut.Handle(email, CancellationToken.None);

        //Assert
        result.Should().BeOfType<Result<DeletarEmailResponse>>().Which
            .Value.EnderecoEmail.Should().NotBeEmpty();
    }
}
