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

public class CriarEstadoCivilHandlerTests
{
    private readonly IEstadoCivilRepository _estadoCivilRepository =
        Substitute.For<IEstadoCivilRepository>();
    private readonly ILogger<CriarEstadoCivilHandler> _logger = Substitute.For<ILogger<CriarEstadoCivilHandler>>();
    private readonly CriarEstadoCivilHandler _sut;
    
    public CriarEstadoCivilHandlerTests()
    {
        _sut = new CriarEstadoCivilHandler(_estadoCivilRepository, _logger);
    }
    
    [Fact]
    public async Task CriarEstadoCivilAsync_QuandoCriar_DeveRetornarSucesso()
    {
        //Arrange 
        var estadoCivil = new CriarEstadoCivilRequest { Descricao = "Solteiro" };
        var estadoCivilEntity = new EstadoCivilEntity { NomeEstadoCivil = "Solteiro" };
        _estadoCivilRepository.CriarEstadoCivilAsync(It.IsAny<EstadoCivilEntity>())
            .ReturnsForAnyArgs(estadoCivilEntity);
        
        //Act
        var result = await _sut.Handle(estadoCivil, CancellationToken.None);
        
        //Assert
        result.Should().BeOfType<Result<CriarEstadoCivilResponse>>().Which
            .Value.DescricaoEstadoCivil.Should().Be(estadoCivil.Descricao);
        result.Should().BeOfType<Result<CriarEstadoCivilResponse>>().Which
            .Value.DescricaoEstadoCivil.Should().NotBeEmpty();
    }
}
