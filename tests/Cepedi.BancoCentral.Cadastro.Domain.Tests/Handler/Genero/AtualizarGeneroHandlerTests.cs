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

public class AtualizarGeneroHandlerTests
{
    private readonly IGeneroRepository _generoRepository =
        Substitute.For<IGeneroRepository>();
    private readonly ILogger<AtualizarGeneroHandler> _logger = Substitute.For<ILogger<AtualizarGeneroHandler>>();
    private readonly AtualizarGeneroHandler _sut;
    private readonly IUnitOfWork _unitOfWork = Substitute.For<IUnitOfWork>();
    
    public AtualizarGeneroHandlerTests()
    {
        _sut = new AtualizarGeneroHandler(_generoRepository, _logger, _unitOfWork);
    }
    
    [Fact]
    public async Task AtualizarGeneroAsync_QuandoAtualizar_DeveRetornarSucesso()
    {
        //Arrange 
        var genero = new AtualizarGeneroRequest { Descricao = "Masculino" };
        var generoEntity = new GeneroEntity { NomeGenero = "Masculino" };
        _generoRepository.ObterGeneroAsync(It.IsAny<int>()).ReturnsForAnyArgs(new GeneroEntity());
        _generoRepository.AtualizarGeneroAsync(It.IsAny<GeneroEntity>())
            .ReturnsForAnyArgs(generoEntity);
        
        //Act
        var result = await _sut.Handle(genero, CancellationToken.None);
        
        //Assert
        result.Should().BeOfType<Result<AtualizarGeneroResponse>>().Which
            .Value.Genero.Should().Be(genero.Descricao);
        result.Should().BeOfType<Result<AtualizarGeneroResponse>>().Which
            .Value.Genero.Should().NotBeEmpty();
    }
}
