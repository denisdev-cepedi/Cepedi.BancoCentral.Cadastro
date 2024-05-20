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

public class CriarGeneroHandlerTests
{
    private readonly IGeneroRepository _generoRepository =
        Substitute.For<IGeneroRepository>();
    private readonly ILogger<CriarGeneroHandler> _logger = Substitute.For<ILogger<CriarGeneroHandler>>();
    private readonly CriarGeneroHandler _sut;
    
    public CriarGeneroHandlerTests()
    {
        _sut = new CriarGeneroHandler(_generoRepository, _logger);
    }
    
    [Fact]
    public async Task CriarGeneroAsync_QuandoCriar_DeveRetornarSucesso()
    {
        //Arrange 
        var genero = new CriarGeneroRequest { Descricao = "Masculino" };
        var generoEntity = new GeneroEntity { NomeGenero = "Masculino" };
        _generoRepository.CriarGeneroAsync(It.IsAny<GeneroEntity>())
            .ReturnsForAnyArgs(generoEntity);
        
        //Act
        var result = await _sut.Handle(genero, CancellationToken.None);
        
        //Assert
        result.Should().BeOfType<Result<CriarGeneroResponse>>().Which
            .Value.Genero.Should().Be(genero.Descricao);
        result.Should().BeOfType<Result<CriarGeneroResponse>>().Which
            .Value.Genero.Should().NotBeEmpty();
    }
}
