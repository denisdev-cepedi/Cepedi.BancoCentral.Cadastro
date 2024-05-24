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

namespace Cepedi.BancoCentral.Cadastro.Dominio.Tests.Pix;

public class GetPixsHandlerTests
{
    private readonly IPixRepository _pixRepository = Substitute.For<IPixRepository>();
    private readonly ILogger<GetPixsHandler> _logger = Substitute.For<ILogger<GetPixsHandler>>();
    private readonly GetPixsHandler _sut;

    public GetPixsHandlerTests()
    {
        _sut = new GetPixsHandler(_pixRepository, _logger);
    }

    [Fact]
    public async Task GetPixsAsync_QuandoAtualizar_DeveRetornarSucesso(){
        // Arrange
        var pixs = new GetPixsRequest();
        var pixEntities = new List<PixEntity>
        {
            new PixEntity { ChavePix = "000.000.000-11", TipoPix = "CPF" },
            new PixEntity { ChavePix = "111.111.111-22", TipoPix = "Telefone" }
        };
         _pixRepository.GetPixsAsync().Returns(pixEntities);

          // Act
        var result = await _sut.Handle(pixs, CancellationToken.None);

        // Assert
            result.Should().BeOfType<Result<List<GetPixsResponse>>>().Which
                .IsSuccess.Should().BeTrue();
            result.Value.Should().HaveCount(2);
            result.Value[0].ChavePix.Should().Be("000.000.000-11");
            result.Value[0].TipoPix.Should().Be("CPF");
            result.Value[1].ChavePix.Should().Be("111.111.111-22");
            result.Value[1].TipoPix.Should().Be("Telefone");

    }
}
