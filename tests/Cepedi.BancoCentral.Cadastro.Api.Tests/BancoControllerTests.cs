using Cepedi.BancoCentral.Cadastro.Api.Controllers;
using Cepedi.BancoCentral.Cadastro.Shareable.Requests;
using Cepedi.BancoCentral.Cadastro.Shareable.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using NSubstitute;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Api.Tests;

public class BancoControllerTests
{
    private readonly IMediator _mediator = Substitute.For<IMediator>();
    private readonly ILogger<BancoController> _logger = Substitute.For<ILogger<BancoController>>();
    private readonly BancoController _sut;
    
    public BancoControllerTests()
    {
        _sut = new BancoController(_mediator, _logger);
    }

    [Fact]
    public async Task CriarBanco_QuandoChamado_EnviarRequestParaMediator()
    {
        // Arrange
        var request = new CriarBancoRequest
        {
            Cnpj = "12345678901234",
            DataCriacao = DateTime.Now,
            NomeFantasia = "Banco Teste",
            NomeReal = "Banco Teste S/A"
        };
        _mediator.Send(request).ReturnsForAnyArgs(Result.Success(new CriarBancoResponse(0, "Banco Teste", "Banco Teste S/A", "12345678901234", DateTime.Now)));
        
        // Act
        await _sut.CriarBancoAsync(request);
        
        // Assert
        await _mediator.ReceivedWithAnyArgs().Send(request);
    }
    
    [Fact]
    public async Task DeletarBanco_QuandoChamado_EnviarRequestParaMediator()
    {
        // Arrange
        var request = new DeletarBancoRequest { IdBanco = 1 };
        _mediator.Send(request).ReturnsForAnyArgs(Result.Success(new DeletarBancoResponse(1, "Banco Teste", "Banco Teste S/A", "12345678901234", DateTime.Now)));
        
        // Act
        await _sut.DeletarBancoAsync(request);
        
        // Assert
        await _mediator.ReceivedWithAnyArgs().Send(request);
    }
    
    [Fact]
    public async Task ObterBanco_QuandoChamado_EnviarRequestParaMediator()
    {
        // Arrange
        var request = new ObtemBancoRequest { IdBanco = 1 };
        _mediator.Send(request).ReturnsForAnyArgs(Result.Success(new ObtemBancoResponse(1, "Banco Teste", "Banco Teste S/A", "12345678901234", DateTime.Now)));
        
        // Act
        await _sut.ObterBancoAsync(1);
        
        // Assert
        await _mediator.ReceivedWithAnyArgs().Send(request);
    }
    
    [Fact]
    public async Task ObterListaBanco_QuandoChamado_EnviarRequestParaMediator()
    {
        // Arrange
        var request = new ObtemListaBancoRequest();
        _mediator.Send(request).ReturnsForAnyArgs(Result.Success(new List<ObtemBancoResponse>()));
        
        // Act
        await _sut.ObterListaBancoAsync();
        
        // Assert
        await _mediator.ReceivedWithAnyArgs().Send(request);
    }
    
    [Fact]
    public async Task AtualizarBanco_QuandoChamado_EnviarRequestParaMediator()
    {
        // Arrange
        var request = new AtualizarBancoRequest
        {
            IdBanco = 1,
            Cnpj = "12345678901234",
            DataCriacao = DateTime.Now,
            NomeFantasia = "Banco Teste",
            NomeReal = "Banco Teste S/A"
        };
        _mediator.Send(request).ReturnsForAnyArgs(Result.Success(new AtualizarBancoResponse(1, "Banco Teste", "Banco Teste S/A", "12345678901234", DateTime.Now)));
        
        // Act
        await _sut.AtualizarBancoAsync(request);
        
        // Assert
        await _mediator.ReceivedWithAnyArgs().Send(request);
    }
}
