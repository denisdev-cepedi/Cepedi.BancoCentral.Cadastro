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

public class CriarTipoPixHandllerTests
{
    private readonly ITipoPixRepository _tipoPixRepository = Substitute.For<ITipoPixRepository>();
    private readonly ILogger<CriarTipoPixHandler> _logger = Substitute.For<ILogger<CriarTipoPixHandler>>();
    private readonly CriarTipoPixHandler _sut;

    public CriarTipoPixHandllerTests(ITipoPixRepository tipoPixRepository, ILogger<CriarTipoPixHandler> logger)
    {
        _tipoPixRepository = tipoPixRepository;
        _logger = logger;
    }

    [Fact]
    public async Task CriarTipoPixAsync_QuandoCriar_DeveRetornarSucesso()
    {
        //Arrange 
        var tipoPix = new CriarTipoPixRequest {TipoPix="CPF" };
        _tipoPixRepository.CriarTipoPixAsync(It.IsAny<TipoPixEntity>())
            .ReturnsForAnyArgs(new TipoPixEntity());

        //Act
        var result = await _sut.Handle(tipoPix, CancellationToken.None);

        //Assert 
        result.Should().BeOfType<Result<CriarTipoPixResponse>>().Which
            .Value.TipoPix.Should().Be(tipoPix.TipoPix);
        result.Should().BeOfType<Result<CriarTipoPixResponse>>().Which
            .Value.TipoPix.Should().NotBeEmpty();
    }

}
