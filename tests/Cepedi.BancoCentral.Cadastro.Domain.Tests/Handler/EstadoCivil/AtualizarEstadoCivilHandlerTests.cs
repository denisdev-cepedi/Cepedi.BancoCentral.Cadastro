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

public class AtualizarEstadoCivilHandlerTests
{
    private readonly IEstadoCivilRepository _estadoCivilRepository =
        Substitute.For<IEstadoCivilRepository>();
    private readonly ILogger<AtualizarEstadoCivilHandler> _logger = Substitute.For<ILogger<AtualizarEstadoCivilHandler>>();
    private readonly AtualizarEstadoCivilHandler _sut;
    private readonly IUnitOfWork _unitOfWork = Substitute.For<IUnitOfWork>();
    
    public AtualizarEstadoCivilHandlerTests()
    {
        _sut = new AtualizarEstadoCivilHandler(_estadoCivilRepository, _logger, _unitOfWork);
    }
    
    [Fact]
    public async Task AtualizarEstadoCivilAsync_QuandoAtualizar_DeveRetornarSucesso()
    {
        //Arrange 
        var estadoCivil = new AtualizarEstadoCivilRequest { Descricao = "Solteiro" };
        var estadoCivilEntity = new EstadoCivilEntity { NomeEstadoCivil = "Solteiro" };
        _estadoCivilRepository.ObterEstadoCivilAsync(It.IsAny<int>()).ReturnsForAnyArgs(new EstadoCivilEntity());
        _estadoCivilRepository.AtualizarEstadoCivilAsync(It.IsAny<EstadoCivilEntity>())
            .ReturnsForAnyArgs(estadoCivilEntity);
        
        //Act
        var result = await _sut.Handle(estadoCivil, CancellationToken.None);
        
        //Assert
        result.Should().BeOfType<Result<AtualizarEstadoCivilResponse>>().Which
            .Value.EstadoCivil.Should().Be(estadoCivil.Descricao);
        result.Should().BeOfType<Result<AtualizarEstadoCivilResponse>>().Which
            .Value.EstadoCivil.Should().NotBeEmpty();
    }
}
