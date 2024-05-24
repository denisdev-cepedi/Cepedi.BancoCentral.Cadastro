using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Handlers;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Shareable.Requests;
using Cepedi.BancoCentral.Cadastro.Shareable.Responses;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using NSubstitute;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Tests.Banco;

public class CriarBancoRequestHandlerTests
{
    private readonly ILogger<CriarBancoRequestHandler> _logger = Substitute.For<ILogger<CriarBancoRequestHandler>>();
    private readonly IBancoRepository _bancoRepository = Substitute.For<IBancoRepository>();
    private readonly CriarBancoRequestHandler _sut;
    
    public CriarBancoRequestHandlerTests()
    {
        _sut = new CriarBancoRequestHandler(_bancoRepository, _logger);
    }
    
    [Fact]
    public async Task CriarBancoAsync_QuandoCriar_RetornarSucesso()
    {
        // Arrange
        var banco = new CriarBancoRequest
        {
            NomeFantasia = "Banco Teste",
            NomeReal = "Banco Teste S/A",
            Cnpj = "12345678901234",
            DataCriacao = DateTime.Now
        };
        _bancoRepository.CriarBancoAsync(It.IsAny<BancoEntity>()).ReturnsForAnyArgs(new BancoEntity());
        
        // Act
        var result = await _sut.Handle(banco, CancellationToken.None);
        
        // Assert
        result.Should().BeOfType<Result<CriarBancoResponse>>().Which.Value.nomeReal.Should().Be(banco.NomeReal);
        result.Should().BeOfType<Result<CriarBancoResponse>>().Which.Value.nomeReal.Should().NotBeEmpty();
    }
}
