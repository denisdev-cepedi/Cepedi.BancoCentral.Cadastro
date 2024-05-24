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

namespace Cepedi.BancoCentral.Cadastro.Dominio.Tests;

public class AtualizarEnderecoHandlerTests
{
    private readonly IEnderecoRepository _enderecoRepository =
        Substitute.For<IEnderecoRepository>();
    private readonly ILogger<AtualizarEnderecoHandler> _logger = Substitute.For<ILogger<AtualizarEnderecoHandler>>();
    private readonly AtualizarEnderecoHandler _sut;
    private readonly IUnitOfWork _unitOfWork = Substitute.For<IUnitOfWork>();
    
    public AtualizarEnderecoHandlerTests()
    {
        _sut = new AtualizarEnderecoHandler(_enderecoRepository, _logger, _unitOfWork);
    }

    [Fact]
    public async Task AtualizarEnderecoAsync_QuandoAtualizar_DeveRetornarSucesso()
    {
        //Arrange 
        var endereco = new AtualizarEnderecoRequest { Cep = "12345678" };
        var enderecoEntity = new EnderecoEntity { Cep = "12345678" };
        _enderecoRepository.ObterEnderecoAsync(It.IsAny<int>()).ReturnsForAnyArgs(new EnderecoEntity());
        _enderecoRepository.AtualizarEnderecoAsync(It.IsAny<EnderecoEntity>())
            .ReturnsForAnyArgs(enderecoEntity);

        //Act
        var result = await _sut.Handle(endereco, CancellationToken.None);

        //Assert
        result.Should().BeOfType<Result<AtualizarEnderecoResponse>>().Which
            .Value.Cep.Should().Be(endereco.Cep);
        result.Should().BeOfType<Result<AtualizarEnderecoResponse>>().Which
            .Value.Cep.Should().NotBeEmpty();
    }
}
