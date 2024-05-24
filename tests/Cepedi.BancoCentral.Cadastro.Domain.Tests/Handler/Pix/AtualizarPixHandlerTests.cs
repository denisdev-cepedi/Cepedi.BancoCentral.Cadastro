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

public class AtualizarPixHandlerTests
{
    private readonly IPixRepository _pixRepository = Substitute.For<IPixRepository>();
    private readonly ILogger<AtualizarPixHandler> _logger = Substitute.For<ILogger<AtualizarPixHandler>>();
    private readonly AtualizarPixHandler _sut;
    
    public AtualizarPixHandlerTests()
    {
        _sut = new AtualizarPixHandler(_pixRepository, _logger);
    }

    [Fact]
    public async Task AtualizarPixAsync_QuandoAtualizar_DeveRetornarSucesso()
    {
        //Arrange 
        var pix = new AtualizarPixRequest { ChavePix = "000.000.000-11" };
        var pixEntity = new PixEntity { ChavePix = "000.000.000-11"};
        _pixRepository.ObterPixAsync(It.IsAny<int>()).ReturnsForAnyArgs(pixEntity);
        _pixRepository.AtualizarPixAsync(It.IsAny<PixEntity>())
            .ReturnsForAnyArgs(pixEntity);

        //Act
        var result = await _sut.Handle(pix, CancellationToken.None);

        //Assert 
        result.Should().BeOfType<Result<AtualizarPixResponse>>().Which
            .Value.ChavePix.Should().Be(pix.ChavePix);

        result.Should().BeOfType<Result<AtualizarPixResponse>>().Which
            .Value.ChavePix.Should().NotBeEmpty();
    }

}
