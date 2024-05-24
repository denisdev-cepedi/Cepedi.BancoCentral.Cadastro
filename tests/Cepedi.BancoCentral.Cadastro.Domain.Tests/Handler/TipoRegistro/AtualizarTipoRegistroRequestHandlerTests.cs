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

public class AtualizarTipoRegistroRequestHandlerTests
{
    private readonly ITipoRegistroRepository _tipoRegistroRepository = Substitute.For<ITipoRegistroRepository>();
    private readonly IUnitOfWork _unitOfWork = Substitute.For<IUnitOfWork>();
    private readonly ILogger<AtualizarTipoRegistroRequestHandler> _logger = Substitute.For<ILogger<AtualizarTipoRegistroRequestHandler>>();

    private readonly AtualizarTipoRegistroRequestHandler _sut;

    public AtualizarTipoRegistroRequestHandlerTests()
    {
        _sut = new AtualizarTipoRegistroRequestHandler(_tipoRegistroRepository, _logger, _unitOfWork);
    }

    [Fact]
    public async Task AtualizarTipoRegistroAsync_QuandoAtualizar_DeveRetornarSucesso()
    {
        //Arrange
        var tipoRegistro = new AtualizarTipoRegistroRequest { IdTipoRegistro = 1, NomeTipo = "TestTipo" };
        var tipoRegistroEntity = new TipoRegistroEntity { IdTipoRegistro = 1, NomeTipo = "TestTipo" };
        _tipoRegistroRepository.ObterTipoRegistroAsync(It.IsAny<int>()).ReturnsForAnyArgs(new TipoRegistroEntity());
        _tipoRegistroRepository.AtualizarTipoRegistroAsync(It.IsAny<TipoRegistroEntity>())
            .ReturnsForAnyArgs(tipoRegistroEntity);

        //Act
        var result = await _sut.Handle(tipoRegistro, CancellationToken.None);

        //Assert
        result.Should().BeOfType<Result<AtualizarTipoRegistroResponse>>().Which
            .Value.nomeTipo.Should().Be(tipoRegistro.NomeTipo);

        result.Should().BeOfType<Result<AtualizarTipoRegistroResponse>>().Which
            .Value.nomeTipo.Should().NotBeEmpty();
    }



}
