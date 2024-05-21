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

public class GetEnderecosHandlerTests
{
    private readonly IEnderecoRepository _enderecoRepository = Substitute.For<IEnderecoRepository>();
    private readonly ILogger<GetEnderecosHandler> _logger = Substitute.For<ILogger<GetEnderecosHandler>>();
    private readonly GetEnderecosHandler _sut;

    public GetEnderecosHandlerTests()
    {
        _sut = new GetEnderecosHandler(_enderecoRepository, _logger);
    }

    [Fact]
    public async Task GetEnderecosAsync_QuandoObter_DeveRetornarSucesso()
    {
        //Arrange 
        var endereco = new GetEnderecosRequest();
        var enderecoEntities = new List<EnderecoEntity>
        {
            new EnderecoEntity { Logradouro = "Rua Teste" }
        };
        _enderecoRepository.GetEnderecosAsync().ReturnsForAnyArgs(enderecoEntities);

        //Act
        var result = await _sut.Handle(endereco, CancellationToken.None);

        //Assert
        result.Should().BeOfType<Result<List<GetEnderecosResponse>>>().Which
            .Value.Should().NotBeEmpty();
    }
}
