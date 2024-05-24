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

namespace Cepedi.BancoCentral.Cadastro.Dominio.Tests.TipoPix;

public class AtualizarTipoPixHandllerTests
{
    private readonly ITipoPixRepository _tipoPixRepository = Substitute.For<ITipoPixRepository>();
    private readonly ILogger<AtualizarTipoPixHandler> _logger = Substitute.For<ILogger<AtualizarTipoPixHandler>>();
    private readonly AtualizarTipoPixHandler _sut;
    
    public AtualizarTipoPixHandllerTests()
    {
        _sut = new AtualizarTipoPixHandler(_tipoPixRepository, _logger);
    }

    [Fact]
    public async Task AtualizarTipoPixAsync_QuandoAtualizar_DeveRetornarSucesso()
    {
        //Arrange 
        var tipoPix = new AtualizarTipoPixRequest { TipoPix = "CPF" };
        var tipoPixEntity = new TipoPixEntity { TipoPix = "CPF"};
        _tipoPixRepository.ObterTipoPixAsync(It.IsAny<int>()).ReturnsForAnyArgs(tipoPixEntity);
        _tipoPixRepository.AtualizarTipoPixAsync(It.IsAny<TipoPixEntity>())
            .ReturnsForAnyArgs(tipoPixEntity);

        //Act
        var result = await _sut.Handle(tipoPix, CancellationToken.None);

        //Assert 
        result.Should().BeOfType<Result<AtualizarTipoPixResponse>>().Which
            .Value.TipoPix.Should().Be(tipoPix.TipoPix);
        result.Should().BeOfType<Result<AtualizarTipoPixResponse>>().Which
            .Value.TipoPix.Should().NotBeEmpty();
    }

}
