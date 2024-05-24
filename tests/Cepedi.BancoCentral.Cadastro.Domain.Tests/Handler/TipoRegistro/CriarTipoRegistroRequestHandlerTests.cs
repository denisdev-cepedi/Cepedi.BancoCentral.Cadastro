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
using Cepedi.BancoCentral.Cadastro.Dominio.Handlers;
namespace Cepedi.BancoCentral.Cadastro.Dominio.Tests;

public class CriarTipoRegistroRequestHandlerTests
{
    private readonly ILogger<CriarTipoRegistroRequestHandler> _logger = Substitute.For<ILogger<CriarTipoRegistroRequestHandler>>();
    private readonly ITipoRegistroRepository _tiporegistroRepository = Substitute.For<ITipoRegistroRepository>();
    private readonly IUnitOfWork _unitOfWork = Substitute.For<IUnitOfWork>();

    private readonly CriarTipoRegistroRequestHandler _sut;

    public CriarTipoRegistroRequestHandlerTests()
    {
        _sut = new CriarTipoRegistroRequestHandler(_tiporegistroRepository, _logger, _unitOfWork);
    }

    [Fact]
    public async Task CriarTipoRegistroAsync_QuandoCriar_DeveRetornarSucesso()
    {
        //Arrange
        var tipoRegistro = new CriarTipoRegistroRequest { NomeTipo = "TestTipo" };

        _tiporegistroRepository.CriarTipoRegistroAsync(It.IsAny<TipoRegistroEntity>())
            .ReturnsForAnyArgs(new TipoRegistroEntity());

        //Act
        var result = await _sut.Handle(tipoRegistro, CancellationToken.None);

        //Assert
        result.Should().BeOfType<Result<CriarTipoRegistroResponse>>().Which
            .Value.nomeTipo.Should().Be(tipoRegistro.NomeTipo);
        
        result.Should().BeOfType<Result<CriarTipoRegistroResponse>>().Which
            .Value.nomeTipo.Should().NotBeEmpty();
    }

}
