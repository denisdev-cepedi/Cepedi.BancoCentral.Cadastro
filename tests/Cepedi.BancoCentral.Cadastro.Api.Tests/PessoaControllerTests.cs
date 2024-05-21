using Cepedi.BancoCentral.Cadastro.Api.Controllers;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using NSubstitute;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Api.Tests;

public class PessoaControllerTests
{
    private readonly IMediator _mediator = Substitute.For<IMediator>();
    private readonly ILogger<PessoaController> _logger = Substitute.For<ILogger<PessoaController>>();
    private readonly PessoaController _sut;

    public PessoaControllerTests()
    {
        _sut = new PessoaController(_logger, _mediator);
    }

    [Fact]
    public async Task CriarPessoa_DeveEnviarRequest_Para_Mediator()
    {
        // Arrange 
        var request = new CriarPessoaRequest { Nome = "João", Cpf = "12345678901" };
        _mediator.Send(request).ReturnsForAnyArgs(Result.Success(new CriarPessoaResponse(1, "Joao")));

        // Act
        await _sut.CriarPessoaAsync(request);

        // Assert
        await _mediator.ReceivedWithAnyArgs().Send(request);
    }

    [Fact]
    public async Task AtualizarPessoa_DeveEnviarRequest_Para_Mediator()
    {
        // Arrange 
        var request = new AtualizarPessoaRequest { IdPessoa = 1, Nome = "João", Cpf = "12345678901" };
        _mediator.Send(request).ReturnsForAnyArgs(Result.Success(new AtualizarPessoaResponse("Joao")));

        // Act
        await _sut.AtualizarPessoaAsync(request);

        // Assert
        await _mediator.ReceivedWithAnyArgs().Send(request);
    }

    [Fact]
    public async Task ExcluirPessoa_DeveEnviarRequest_Para_Mediator()
    {
        // Arrange 
        var request = new DeletarPessoaRequest { Id = 1 };
        _mediator.Send(request).ReturnsForAnyArgs(Result.Success(new DeletarPessoaResponse(1, "Joao")));

        // Act
        await _sut.DeletarPessoaAsync(request);
    }    
}
