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

public class DeletarBancoRequestHandlerTests
{
    private readonly ILogger<DeletarBancoRequestHandler> _logger = Substitute.For<ILogger<DeletarBancoRequestHandler>>();
    private readonly IBancoRepository _bancoRepository = Substitute.For<IBancoRepository>();
    private readonly DeletarBancoRequestHandler _sut;

    public DeletarBancoRequestHandlerTests()
    {
        _sut = new DeletarBancoRequestHandler(_bancoRepository, _logger);
    }
    
    [Fact]
    public async Task DeletarBancoAsync_QuandoDeletar_RetornarSucesso()
    {
        // Arrange
        var banco = new DeletarBancoRequest
        {
            IdBanco = 1
        };
        var bancoEntity = new BancoEntity
        {
            IdBanco = 1,
            NomeFantasia = "Banco Teste",
            NomeReal = "Banco Teste S/A",
            Cnpj = "12345678901234",
            DataCriacao = DateTime.Now
        };
        _bancoRepository.ObterBancoAsync(It.IsAny<int>()).ReturnsForAnyArgs(bancoEntity);
        _bancoRepository.DeletarBancoAsync(It.IsAny<BancoEntity>()).Returns(new BancoEntity());
        
        // Act
        var result = await _sut.Handle(banco, CancellationToken.None);
        
        // Assert
        result.Should().BeOfType<Result<DeletarBancoResponse>>().Which.Value.idBanco.Should().Be(banco.IdBanco);
        result.Should().BeOfType<Result<DeletarBancoResponse>>().Which.Value.nomeReal.Should().Be(bancoEntity.NomeReal);
    }
}
