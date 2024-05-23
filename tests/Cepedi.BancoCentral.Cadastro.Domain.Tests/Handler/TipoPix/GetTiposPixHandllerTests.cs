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

public class GetTiposPixHandllerTests
{
    private readonly ITipoPixRepository _tipoPixRepository = Substitute.For<ITipoPixRepository>();
    private readonly ILogger<GetTiposPixHandler> _logger = Substitute.For<ILogger<GetTiposPixHandler>>();
    private readonly GetTiposPixHandler _sut;

    public GetTiposPixHandllerTests()
    {
        _sut = new GetTiposPixHandler(_tipoPixRepository, _logger);
    }

    [Fact]
    public async Task GetPixsAsync_QuandoAtualizar_DeveRetornarSucesso(){
        // Arrange
        var tiposPix = new GetTiposPixRequest();
        var tiposPixEntities = new List<TipoPixEntity>
        {
            new TipoPixEntity { TipoPix = "Telefone" },
            new TipoPixEntity { TipoPix = "CPF"  }
        };
         _tipoPixRepository.GetTipoPixsAync().Returns(tiposPixEntities);

          // Act
        var result = await _sut.Handle(tiposPix, CancellationToken.None);

        // Assert
            result.Should().BeOfType<Result<List<GetTiposPixResponse>>>().Which
                .IsSuccess.Should().BeTrue();
            result.Value.Should().HaveCount(2);
            result.Value[0].TipoPix.Should().Be("Telefone");
            result.Value[1].TipoPix.Should().Be("CPF");

    }

}
