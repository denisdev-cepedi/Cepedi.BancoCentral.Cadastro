using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using NSubstitute;
using OperationResult;
namespace Cepedi.BancoCentral.Cadastro.Dominio.Tests;

public class ObtemListaTipoRegistroRequestHandlerTests
{
    private readonly ILogger<ObtemListaTipoRegistroRequestHandler> _logger = Substitute.For<ILogger<ObtemListaTipoRegistroRequestHandler>>();

    private readonly ITipoRegistroRepository _tiporegistroRepository = Substitute.For<ITipoRegistroRepository>();

    private readonly ObtemListaTipoRegistroRequestHandler _sut;

    public ObtemListaTipoRegistroRequestHandlerTests()
    {
        _sut = new ObtemListaTipoRegistroRequestHandler(_tiporegistroRepository, _logger);
    }

    [Fact]
    public async Task ObtemListaTipoRegistroAsync_QuandoObter_DeveRetornarSucesso()
    {
        //Arrange
        var tipoRegistro = new ObtemListaTipoRegistroRequest();
        var tipoRegistroEntity = new TipoRegistroEntity { IdTipoRegistro = 1, NomeTipo = "TestTipo" };

        _tiporegistroRepository.ObterTipoRegistroAsync()
            .ReturnsForAnyArgs(new List<TipoRegistroEntity> { tipoRegistroEntity });

        //Act
        var result = await _sut.Handle(tipoRegistro, CancellationToken.None);

        //Assert
        result.Should().BeOfType<Result<List<ObtemTipoRegistroResponse>>>().Which
             .Value.Should().NotBeEmpty();
        result.Should().BeOfType<Result<List<ObtemTipoRegistroResponse>>>().Which
                .Value.Should().HaveCount(1);
    }

}
