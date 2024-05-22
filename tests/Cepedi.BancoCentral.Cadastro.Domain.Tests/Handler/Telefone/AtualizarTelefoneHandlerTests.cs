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

public class AtualizarTelefoneHandlerTests
{
    private readonly ITelefoneRepository _telefoneRepository =
        Substitute.For<ITelefoneRepository>();
    private readonly ILogger<AtualizarTelefoneHandler> _logger = Substitute.For<ILogger<AtualizarTelefoneHandler>>();
    private readonly AtualizarTelefoneHandler _sut;
    private readonly IUnitOfWork _unitOfWork = Substitute.For<IUnitOfWork>();
    
    public AtualizarTelefoneHandlerTests()
    {
        _sut = new AtualizarTelefoneHandler(_telefoneRepository, _logger, _unitOfWork);
    }
    
    [Fact]
    public async Task AtualizarTelefoneAsync_QuandoAtualizar_DeveRetornarSucesso()
    {
        //Arrange 
        var telefone = new AtualizarTelefoneRequest { NumeroTelefone = "123456789" };
        var telefoneEntity = new TelefoneEntity { NumeroTelefone = "123456789" };
        _telefoneRepository.ObterTelefoneAsync(It.IsAny<int>()).ReturnsForAnyArgs(new TelefoneEntity());
        _telefoneRepository.AtualizarTelefoneAsync(It.IsAny<TelefoneEntity>())
            .ReturnsForAnyArgs(telefoneEntity);
        
        //Act
        var result = await _sut.Handle(telefone, CancellationToken.None);
        
        //Assert
        result.Should().BeOfType<Result<AtualizarTelefoneResponse>>().Which
            .Value.Telefone.Should().Be(telefone.NumeroTelefone);
        result.Should().BeOfType<Result<AtualizarTelefoneResponse>>().Which
            .Value.Telefone.Should().NotBeEmpty();
    }    
}
