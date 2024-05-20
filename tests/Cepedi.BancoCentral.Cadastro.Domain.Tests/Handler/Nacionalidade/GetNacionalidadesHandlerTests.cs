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

namespace Cepedi.BancoCentral.Cadastro.Dominio.Tests.Nacionalidade;

public class GetNacionalidadesHandlerTests
{
    private readonly INacionalidadeRepository _nacionalidadeRepository = Substitute.For<INacionalidadeRepository>();
    private readonly ILogger<GetNacionalidadesHandler> _logger = Substitute.For<ILogger<GetNacionalidadesHandler>>();
    private readonly GetNacionalidadesHandler _sut;

    public GetNacionalidadesHandlerTests()
    {
        _sut = new GetNacionalidadesHandler(_nacionalidadeRepository, _logger);
    }

    [Fact]
    public async Task GetNacionalidadesAsync_QuandoObter_DeveRetornarSucesso()
    {
        //Arrange 
        var nacionalidade = new GetNacionalidadesRequest();
        var nacionalidadeEntities = new List<NacionalidadeEntity>
        {
            new NacionalidadeEntity { NomeNacionalidade = "Brasileira" }
        };
        _nacionalidadeRepository.GetNacionalidadesAsync().ReturnsForAnyArgs(nacionalidadeEntities);

        //Act
        var result = await _sut.Handle(nacionalidade, CancellationToken.None);

        //Assert
        result.Should().BeOfType<Result<List<GetNacionalidadesResponse>>>().Which
            .Value.Should().NotBeEmpty();
    }
}
