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

public class DeletarPixHandlerTests
{
    private readonly IPixRepository _pixRepository = Substitute.For<IPixRepository>();
    private readonly ILogger<DeletarPixHandler> _logger = Substitute.For<ILogger<DeletarPixHandler>>();
    private readonly DeletarPixHandler _sut;

    public DeletarPixHandlerTests()
    {
        _sut = new DeletarPixHandler(_pixRepository, _logger);
    }

    [Fact]
    public async Task DeletarPixAsync_QuandoAtualizar_DeveRetornarSucesso()
    {
        //Arrange 
        var pix = new DeletarPixRequest { IdPix = 0 };
        _pixRepository.ObterPixAsync(It.IsAny<int>()).ReturnsForAnyArgs(new PixEntity());
        _pixRepository.DeletarPixAsync(It.IsAny<PixEntity>())
            .ReturnsForAnyArgs(new PixEntity());

        //Act
        var result = await _sut.Handle(pix, CancellationToken.None);

        //Assert 
        result.Should().BeOfType<Result<DeletarPixResponse>>().Which
            .Value.Pix.Should().Be(pix.IdPix.ToString());
        result.Should().BeOfType<Result<DeletarPixResponse>>().Which
            .Value.Pix.Should().NotBeEmpty();
    }
}
