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

namespace Cepedi.BancoCentral.Cadastro.Dominio.Tests.Pix;

public class CriarPixHandlerTests
{
    private readonly IPixRepository _pixRepository = Substitute.For<IPixRepository>();
    private readonly ILogger<CriarPixHandler> _logger = Substitute.For<ILogger<CriarPixHandler>>();
    private readonly CriarPixHandler _sut;

    public CriarPixHandlerTests()
    {
        _sut = new CriarPixHandler(_pixRepository, _logger);
    }

    [Fact]
    public async Task CriarUsuarioAsync_QuandoCriar_DeveRetornarSucesso()
    {
        //Arrange 
        var pix = new CriarPixRequest {ChavePix="CPF" };
        _pixRepository.CriarPixAsync(It.IsAny<PixEntity>())
            .ReturnsForAnyArgs(new PixEntity());

        //Act
        var result = await _sut.Handle(pix, CancellationToken.None);

        //Assert 
        result.Should().BeOfType<Result<CriarPixResponse>>().Which
            .Value.ChavePix.Should().Be(pix.ChavePix);
        result.Should().BeOfType<Result<CriarPixResponse>>().Which
            .Value.ChavePix.Should().NotBeEmpty();
    }

}
