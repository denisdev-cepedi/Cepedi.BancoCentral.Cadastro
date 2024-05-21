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

namespace Cepedi.BancoCentral.Cadastro.Dominio.Tests.EstadoCivil;

public class DeletarEnderecoHandlerTests
{
    private readonly IEnderecoRepository _enderecoRepository = Substitute.For<IEnderecoRepository>();
    private readonly ILogger<DeletarEnderecoHandler> _logger = Substitute.For<ILogger<DeletarEnderecoHandler>>();
    private readonly DeletarEnderecoHandler _sut;

    public DeletarEnderecoHandlerTests()
    {
        _sut = new DeletarEnderecoHandler(_enderecoRepository, _logger);
    }

    [Fact]
    public async Task DeletarEnderecoAsync_QuandoDeletar_DeveRetornarSucesso()
    {
        //Arrange 
        var endereco = new DeletarEnderecoRequest { Id = 0 };
        _enderecoRepository.ObterEnderecoAsync(It.IsAny<int>())
            .ReturnsForAnyArgs(new EnderecoEntity());
        _enderecoRepository.DeletarEnderecoAsync(It.IsAny<EnderecoEntity>())
            .ReturnsForAnyArgs(new EnderecoEntity());

        //Act
        var result = await _sut.Handle(endereco, CancellationToken.None);

        //Assert
        result.Should().BeOfType<Result<DeletarEnderecoResponse>>().Which
            .Value.Endereco.Should().NotBeEmpty();
    }
}
