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

public class DeletarTipoPixHandllerTests
{
    private readonly ITipoPixRepository _tipoPixRepository = Substitute.For<ITipoPixRepository>();
    private readonly ILogger<DeletarTipoPixHandler> _logger = Substitute.For<ILogger<DeletarTipoPixHandler>>();
    private readonly DeletarTipoPixHandler _sut;

    public DeletarTipoPixHandllerTests()
    {
        _sut = new DeletarTipoPixHandler(_tipoPixRepository, _logger);
    }

    [Fact]
    public async Task DeletarPixAsync_QuandoAtualizar_DeveRetornarSucesso()
    {
        //Arrange 
        var tipoPix = new DeletarTipoPixRequest { IdTipoPix = 0};
        _tipoPixRepository.ObterTipoPixAsync(It.IsAny<int>()).ReturnsForAnyArgs(new TipoPixEntity());
        _tipoPixRepository.DeletarTipoPixAsync(It.IsAny<int>())
            .ReturnsForAnyArgs(new TipoPixEntity());

        //Act
        var result = await _sut.Handle(tipoPix, CancellationToken.None);

        //Assert 
        result.Should().BeOfType<Result<DeletarTipoPixResponse>>().Which
            .Value.IdTipoPix.Should().Be(tipoPix.IdTipoPix);
        result.Should().BeOfType<Result<DeletarTipoPixResponse>>().Which
            .Value.IdTipoPix.Should();
    }

}
