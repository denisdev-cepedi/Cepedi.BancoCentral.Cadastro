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

namespace Cepedi.BancoCentral.Cadastro.Dominio.Tests.Genero;

public class GetGenerosHandlerTests
{
    private readonly IGeneroRepository _generoRepository = Substitute.For<IGeneroRepository>();
    private readonly ILogger<GetGenerosHandler> _logger = Substitute.For<ILogger<GetGenerosHandler>>();
    private readonly GetGenerosHandler _sut;

    public GetGenerosHandlerTests()
    {
        _sut = new GetGenerosHandler(_generoRepository, _logger);
    }

    [Fact]
    public async Task GetGenerosAsync_QuandoObter_DeveRetornarSucesso()
    {
        //Arrange 
        var genero = new GetGenerosRequest();
        var generoEntities = new List<GeneroEntity>
        {
            new GeneroEntity { NomeGenero = "Masculino" }
        };
        _generoRepository.GetGenerosAsync().ReturnsForAnyArgs(generoEntities);

        //Act
        var result = await _sut.Handle(genero, CancellationToken.None);

        //Assert
        result.Should().BeOfType<Result<List<GetGenerosResponse>>>().Which
            .Value.Should().NotBeEmpty();
    }
}
