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

public class CriarEnderecoHandlerTests
{
    private readonly IEnderecoRepository _enderecoRepository =
        Substitute.For<IEnderecoRepository>();
    private readonly ILogger<CriarEnderecoHandler> _logger = Substitute.For<ILogger<CriarEnderecoHandler>>();
    private readonly CriarEnderecoHandler _sut;
    private readonly IUnitOfWork _unitOfWork = Substitute.For<IUnitOfWork>();

    public CriarEnderecoHandlerTests()
    {
        _sut = new CriarEnderecoHandler(_enderecoRepository, _logger, _unitOfWork);
    }

    [Fact]
    public async Task CriarEnderecoAsync_QuandoCriar_DeveRetornarSucesso()
    {
        //Arrange 
        var endereco = new CriarEnderecoRequest { Cep = "12345678" };
        var enderecoEntity = new EnderecoEntity { Cep = "12345678" };
        _enderecoRepository.CriarEnderecoAsync(It.IsAny<EnderecoEntity>())
            .ReturnsForAnyArgs(enderecoEntity);

        //Act
        var result = await _sut.Handle(endereco, CancellationToken.None);

        //Assert
        result.Should().BeOfType<Result<CriarEnderecoResponse>>().Which
            .Value.Cep.Should().Be(endereco.Cep);
        result.Should().BeOfType<Result<CriarEnderecoResponse>>().Which
            .Value.Cep.Should().NotBeEmpty();
    }
}
