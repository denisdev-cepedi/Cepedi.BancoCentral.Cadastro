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

namespace Cepedi.BancoCentral.Cadastro.Dominio.Tests.Pessoa;

public class GetPessoasHandlerTests
{
    private readonly IPessoaRepository _pessoaRepository = Substitute.For<IPessoaRepository>();
    private readonly ILogger<GetPessoasHandler> _logger = Substitute.For<ILogger<GetPessoasHandler>>();
    private readonly GetPessoasHandler _sut;

    public GetPessoasHandlerTests()
    {
        _sut = new GetPessoasHandler(_pessoaRepository, _logger);
    }

    [Fact]
    public async Task GetPessoasAsync_QuandoObter_DeveRetornarSucesso()
    {
        //Arrange 
        var pessoa = new GetPessoasRequest();
        var pessoaEntities = new List<PessoaEntity>
        {
            new PessoaEntity { Nome = "Teste" }
        };
        _pessoaRepository.GetPessoasAsync().ReturnsForAnyArgs(pessoaEntities);

        //Act
        var result = await _sut.Handle(pessoa, CancellationToken.None);

        //Assert
        result.Should().BeOfType<Result<List<GetPessoasResponse>>>().Which
            .Value.Should().NotBeEmpty();
    }
}
