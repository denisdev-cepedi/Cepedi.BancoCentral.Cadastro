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

public class CriarNacionalidadeHandlerTests
{
    private readonly INacionalidadeRepository _nacionalidadeRepository =
        Substitute.For<INacionalidadeRepository>();
    private readonly ILogger<CriarNacionalidadeHandler> _logger = Substitute.For<ILogger<CriarNacionalidadeHandler>>();
    private readonly CriarNacionalidadeHandler _sut;
    private readonly IUnitOfWork _unitOfWork = Substitute.For<IUnitOfWork>();
    
    public CriarNacionalidadeHandlerTests()
    {
        _sut = new CriarNacionalidadeHandler(_nacionalidadeRepository, _logger, _unitOfWork);
    }
    
    [Fact]
    public async Task CriarNacionalidadeAsync_QuandoCriar_DeveRetornarSucesso()
    {
        //Arrange 
        var nacionalidade = new CriarNacionalidadeRequest { Descricao = "Brasileiro" };
        var nacionalidadeEntity = new NacionalidadeEntity { NomeNacionalidade = "Brasileiro" };
        _nacionalidadeRepository.CriarNacionalidadeAsync(It.IsAny<NacionalidadeEntity>())
            .ReturnsForAnyArgs(nacionalidadeEntity);
        
        //Act
        var result = await _sut.Handle(nacionalidade, CancellationToken.None);
        
        //Assert
        result.Should().BeOfType<Result<CriarNacionalidadeResponse>>().Which
            .Value.Nacionalidade.Should().Be(nacionalidade.Descricao);
        result.Should().BeOfType<Result<CriarNacionalidadeResponse>>().Which
            .Value.Nacionalidade.Should().NotBeEmpty();
    }    
}
