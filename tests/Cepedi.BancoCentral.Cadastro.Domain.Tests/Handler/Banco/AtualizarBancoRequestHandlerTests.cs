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

public class AtualizarBancoRequestHandlerTests
{
    private readonly IBancoRepository _bancoRepository = Substitute.For<IBancoRepository>();
    private readonly ILogger<AtualizarBancoRequestHandler> _logger = Substitute.For<ILogger<AtualizarBancoRequestHandler>>();
    private readonly AtualizarBancoRequestHandler _sut;
    
    public AtualizarBancoRequestHandlerTests()
    {
        _sut = new AtualizarBancoRequestHandler(_bancoRepository, _logger);
    }

    [Fact]
    public async Task AtualizarBancoAsync_QuandoAtualizar_RetornarSucesso()
    {
        // Arrange
        var banco = new AtualizarBancoRequest
        {
            IdBanco = 1,
            NomeFantasia = "Banco Teste",
            NomeReal = "Banco Teste S/A",
            Cnpj = "12345678901234",
            DataCriacao = DateTime.Now
        };
        var bancoEntity = new BancoEntity
        {
            IdBanco = 1,
            NomeFantasia = "Banco Teste",
            NomeReal = "Banco Teste S/A",
            Cnpj = "12345678901234",
            DataCriacao = DateTime.Now
        };
        _bancoRepository.ObterBancoAsync(It.IsAny<int>()).ReturnsForAnyArgs(new BancoEntity());
        _bancoRepository.AtualizarBancoAsync(It.IsAny<BancoEntity>()).ReturnsForAnyArgs(bancoEntity);
        
        // Act
        var result = await _sut.Handle(banco, CancellationToken.None);
        
        // Assert
        result.Should().BeOfType<Result<AtualizarBancoResponse>>().Which.Value.nomeReal.Should().Be(banco.NomeReal);
        result.Should().BeOfType<Result<AtualizarBancoResponse>>().Which.Value.nomeReal.Should().NotBeEmpty();
    }
}
