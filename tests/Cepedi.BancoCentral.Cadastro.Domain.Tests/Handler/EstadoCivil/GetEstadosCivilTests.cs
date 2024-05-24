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

namespace Cepedi.BancoCentral.Cadastro.Dominio.Tests.EstadoCivil;

public class GetEstadosCivilTests
{
    private readonly IEstadoCivilRepository _estadoCivilRepository = Substitute.For<IEstadoCivilRepository>();
    private readonly ILogger<GetEstadosCivilHandler> _logger = Substitute.For<ILogger<GetEstadosCivilHandler>>();
    private readonly GetEstadosCivilHandler _sut;

    public GetEstadosCivilTests()
    {
        _sut = new GetEstadosCivilHandler(_estadoCivilRepository, _logger);
    }

    [Fact]
    public async Task GetEstadosCivilAsync_QuandoObter_DeveRetornarSucesso()
    {
        //Arrange 
        var estadoCivil = new GetEstadosCivilRequest();
        var estadoCivilEntities = new List<EstadoCivilEntity>
        {
            new EstadoCivilEntity { NomeEstadoCivil = "Solteiro" }
        };
        _estadoCivilRepository.GetEstadosCivilAsync().ReturnsForAnyArgs(estadoCivilEntities);

        //Act
        var result = await _sut.Handle(estadoCivil, CancellationToken.None);

        //Assert
        result.Should().BeOfType<Result<List<GetEstadosCivilResponse>>>().Which
            .Value.Should().NotBeEmpty();
    }
}
