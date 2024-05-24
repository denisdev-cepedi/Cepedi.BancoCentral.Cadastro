using Moq;
using Xunit;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Microsoft.Extensions.Logging;
using Cepedi.BancoCentral.Cadastro.Dominio.Handlers;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using System.Threading.Tasks;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;

public class CriarTipoPixHandllerTests
{
    private readonly Mock<ITipoPixRepository> _tipoPixRepositoryMock;
    private readonly Mock<ILogger<CriarTipoPixHandler>> _loggerMock;
    private readonly CriarTipoPixHandler _handler;

    public CriarTipoPixHandllerTests()
    {
        _tipoPixRepositoryMock = new Mock<ITipoPixRepository>();
        _loggerMock = new Mock<ILogger<CriarTipoPixHandler>>();
        _handler = new CriarTipoPixHandler(_tipoPixRepositoryMock.Object, _loggerMock.Object);
    }

    [Fact]
    public async Task CriarTipoPixAsync_QuandoCriar_DeveRetornarSucesso()
    {
        // Arrange
        var tipoPix = new TipoPixEntity { IdTipoPix = 1, TipoPix = "ChaveTeste" };
        _tipoPixRepositoryMock.Setup(repo => repo.CriarTipoPixAsync(It.IsAny<TipoPixEntity>())).ReturnsAsync(tipoPix);

        // Act
        var result = await _handler.Handle(new CriarTipoPixRequest { TipoPix = "ChaveTeste" }, default);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.IsSuccess);
    }
}
