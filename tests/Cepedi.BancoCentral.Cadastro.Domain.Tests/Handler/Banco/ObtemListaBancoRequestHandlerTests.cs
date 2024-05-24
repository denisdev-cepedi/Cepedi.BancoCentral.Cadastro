using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Handlers;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Shareable.Requests;
using Cepedi.BancoCentral.Cadastro.Shareable.Responses;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Tests.Banco;

public class ObtemListaBancoRequestHandlerTests
{
    private readonly ILogger<ObtemListaBancoRequestHandler> _logger = Substitute.For<ILogger<ObtemListaBancoRequestHandler>>();
    private readonly IBancoRepository _bancoRepository = Substitute.For<IBancoRepository>();
    private readonly ObtemListaBancoRequestHandler _sut;
    
    public ObtemListaBancoRequestHandlerTests()
    {
        _sut = new ObtemListaBancoRequestHandler(_bancoRepository, _logger);
    }
    
    [Fact]
    public async Task ObtemListaBancoAsync_QuandoObter_RetornarSucesso()
    {
        // Arrange
        var banco = new ObtemListaBancoRequest();
        var bancoEntity = new BancoEntity
        {
            IdBanco = 1,
            NomeFantasia = "Banco Teste",
            NomeReal = "Banco Teste S/A",
            Cnpj = "12345678901234",
            DataCriacao = DateTime.Now
        };
        _bancoRepository.ObterBancoAsync().ReturnsForAnyArgs(new List<BancoEntity> { bancoEntity });
        
        // Act
        var result = await _sut.Handle(banco, CancellationToken.None);
        
        // Assert
        result.Should().BeOfType<Result<List<ObtemBancoResponse>>>().Which.Value.Should().NotBeEmpty();
        result.Should().BeOfType<Result<List<ObtemBancoResponse>>>().Which.Value.Should().HaveCount(1);
    }
}
