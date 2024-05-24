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

public class ObtemBancoRequestHandlerTests
{
    private readonly ILogger<ObtemBancoRequestHandler> _logger = Substitute.For<ILogger<ObtemBancoRequestHandler>>();
    private readonly IBancoRepository _bancoRepository = Substitute.For<IBancoRepository>();
    private readonly ObtemBancoRequestHandler _sut;
    
    public ObtemBancoRequestHandlerTests()
    {
        _sut = new ObtemBancoRequestHandler(_bancoRepository, _logger);
    }
    
    [Fact]
    public async Task ObtemBancoAsync_QuandoObter_RetornarSucesso()
    {
        // Arrange
        var banco = new ObtemBancoRequest{IdBanco = 1};
        var bancoEntity = new BancoEntity
        {
            IdBanco = 1,
            NomeFantasia = "Banco Teste",
            NomeReal = "Banco Teste S/A",
            Cnpj = "12345678901234",
            DataCriacao = DateTime.Now
        };
        _bancoRepository.ObterBancoAsync(banco.IdBanco).ReturnsForAnyArgs(bancoEntity);
        
        // Act
        var result = await _sut.Handle(banco, CancellationToken.None);
        
        // Assert
        result.Should().BeOfType<Result<ObtemBancoResponse>>().Which.Value.Should().NotBeNull();
        result.Should().BeOfType<Result<ObtemBancoResponse>>().Which.Value.idBanco.Should().Be(bancoEntity.IdBanco);
    }
}
