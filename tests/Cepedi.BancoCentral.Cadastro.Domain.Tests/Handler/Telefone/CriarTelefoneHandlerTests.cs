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

namespace Cepedi.BancoCentral.Cadastro.Dominio.Tests.Telefone;

public class CriarTelefoneHandlerTests
{
    private readonly ITelefoneRepository _telefoneRepository =
        Substitute.For<ITelefoneRepository>();
    private readonly ILogger<CriarTelefoneHandler> _logger = Substitute.For<ILogger<CriarTelefoneHandler>>();
    private readonly CriarTelefoneHandler _sut;
    private readonly IUnitOfWork _unitOfWork = Substitute.For<IUnitOfWork>();
    
    public CriarTelefoneHandlerTests()
    {
        _sut = new CriarTelefoneHandler(_telefoneRepository, _logger, _unitOfWork);
    }
    
    [Fact]
    public async Task CriarTelefoneAsync_QuandoCriar_DeveRetornarSucesso()
    {
        //Arrange 
        var telefone = new CriarTelefoneRequest { NumeroTelefone = "123456789" };
        var telefoneEntity = new TelefoneEntity { NumeroTelefone = "123456789" };
        _telefoneRepository.CriarTelefoneAsync(It.IsAny<TelefoneEntity>())
            .ReturnsForAnyArgs(telefoneEntity);
        
        //Act
        var result = await _sut.Handle(telefone, CancellationToken.None);
        
        //Assert
        result.Should().BeOfType<Result<CriarTelefoneResponse>>().Which
            .Value.Telefone.Should().Be(telefone.NumeroTelefone);
        result.Should().BeOfType<Result<CriarTelefoneResponse>>().Which
            .Value.Telefone.Should().NotBeEmpty();
    }    
}
