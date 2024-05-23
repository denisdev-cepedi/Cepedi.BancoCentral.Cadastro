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

public class AtualizarNacionalidadeHandlerTests
{
    private readonly INacionalidadeRepository _nacionalidadeRepository =
        Substitute.For<INacionalidadeRepository>();
    private readonly ILogger<AtualizarNacionalidadeHandler> _logger = Substitute.For<ILogger<AtualizarNacionalidadeHandler>>();
    private readonly AtualizarNacionalidadeHandler _sut;
    private readonly IUnitOfWork _unitOfWork = Substitute.For<IUnitOfWork>();
    
    public AtualizarNacionalidadeHandlerTests()
    {
        _sut = new AtualizarNacionalidadeHandler(_nacionalidadeRepository, _logger, _unitOfWork);
    }
    
    [Fact]
    public async Task AtualizarNacionalidadeAsync_QuandoAtualizar_DeveRetornarSucesso()
    {
        //Arrange 
        var nacionalidade = new AtualizarNacionalidadeRequest { Descricao = "Brasileiro" };
        var nacionalidadeEntity = new NacionalidadeEntity { NomeNacionalidade = "Brasileiro" };
        _nacionalidadeRepository.ObterNacionalidadeAsync(It.IsAny<int>()).ReturnsForAnyArgs(new NacionalidadeEntity());
        _nacionalidadeRepository.AtualizarNacionalidadeAsync(It.IsAny<NacionalidadeEntity>())
            .ReturnsForAnyArgs(nacionalidadeEntity);
        
        //Act
        var result = await _sut.Handle(nacionalidade, CancellationToken.None);
        
        //Assert
        result.Should().BeOfType<Result<AtualizarNacionalidadeResponse>>().Which
            .Value.Nacionalidade.Should().Be(nacionalidade.Descricao);
        result.Should().BeOfType<Result<AtualizarNacionalidadeResponse>>().Which
            .Value.Nacionalidade.Should().NotBeEmpty();
    }
}
