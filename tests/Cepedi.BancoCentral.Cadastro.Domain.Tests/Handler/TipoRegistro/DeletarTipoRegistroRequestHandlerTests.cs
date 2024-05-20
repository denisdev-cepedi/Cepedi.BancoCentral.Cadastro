using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using NSubstitute;
using OperationResult;
using Cepedi.BancoCentral.Cadastro.Dominio;
namespace Cepedi.BancoCentral.Cadastro.Dominio.Tests;
public class DeletarTipoRegistroRequestHandlerTests
{
    private readonly ILogger<DeletarTipoRegistroRequestHandler> _logger = Substitute.For<ILogger<DeletarTipoRegistroRequestHandler>>();
    private readonly ITipoRegistroRepository _tiporegistroRepository = Substitute.For<ITipoRegistroRepository>();

    private readonly DeletarTipoRegistroRequestHandler _sut;

    public DeletarTipoRegistroRequestHandlerTests()
    {
        _sut = new DeletarTipoRegistroRequestHandler(_tiporegistroRepository, _logger);
    }

    [Fact]
    public async Task DeletarTipoRegistroAsync_QuandoDeletar_DeveRetornarSucesso()
    {
       //Arrange
        var tipoRegistro = new DeletarTipoRegistroRequest { IdTipoRegistro = 1 };
        var tipoRegistroEntity = new TipoRegistroEntity { IdTipoRegistro = 1, NomeTipo = "TestTipo" };

        _tiporegistroRepository.ObterTipoRegistroAsync(It.IsAny<int>())
            .ReturnsForAnyArgs(tipoRegistroEntity);
        _tiporegistroRepository.DeletarTipoRegistroAsync(It.IsAny<TipoRegistroEntity>())
            .Returns(new TipoRegistroEntity());

        //Act
        var result = await _sut.Handle(tipoRegistro, CancellationToken.None);

        //Assert
        result.Should().BeOfType<Result<DeletarTipoRegistroResponse>>().Which
            .Value.idTipoRegistro.Should().Be(tipoRegistro.IdTipoRegistro);
        result.Should().BeOfType<Result<DeletarTipoRegistroResponse>>().Which
            .Value.nomeTipo.Should().Be(tipoRegistroEntity.NomeTipo);
    }

}
