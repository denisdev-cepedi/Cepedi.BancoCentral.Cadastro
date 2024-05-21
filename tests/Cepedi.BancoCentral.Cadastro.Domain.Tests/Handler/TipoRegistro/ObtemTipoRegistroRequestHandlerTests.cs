using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using NSubstitute;
using OperationResult;
using Cepedi.BancoCentral.Cadastro.Dominio.Handlers;
namespace Cepedi.BancoCentral.Cadastro.Dominio.Tests;

public class ObtemTipoRegistroRequestHandlerTests
{
    private readonly ILogger<ObtemTipoRegistroRequestHandler> _logger = Substitute.For<ILogger<ObtemTipoRegistroRequestHandler>>();
    private readonly ITipoRegistroRepository _tiporegistroRepository = Substitute.For<ITipoRegistroRepository>();
    private readonly ObtemTipoRegistroRequestHandler _sut;

    public ObtemTipoRegistroRequestHandlerTests()
    {
        _sut = new ObtemTipoRegistroRequestHandler(_tiporegistroRepository, _logger);
    }

    [Fact]
    public async Task ObtemTipoRegistroAsync_QuandoObter_DeveRetornarSucesso()
    {
        //Arrange
        var tipoRegistro = new ObtemTipoRegistroRequest{ IdTipoRegistro = 1 };
        var tipoRegistroEntity = new TipoRegistroEntity { IdTipoRegistro = 1, NomeTipo = "TestTipo" };

        _tiporegistroRepository.ObterTipoRegistroAsync( tipoRegistro.IdTipoRegistro)
            .ReturnsForAnyArgs(tipoRegistroEntity);

        //Act
        var result = await _sut.Handle(tipoRegistro, CancellationToken.None);

        //Assert
        ;
        result.Should().BeOfType<Result<ObtemTipoRegistroResponse>>().Which
                .Value.Should().NotBeNull();
        result.Should().BeOfType<Result<ObtemTipoRegistroResponse>>().Which
                .Value.idTipoRegistro.Should().Be(tipoRegistroEntity.IdTipoRegistro);
    }


}
