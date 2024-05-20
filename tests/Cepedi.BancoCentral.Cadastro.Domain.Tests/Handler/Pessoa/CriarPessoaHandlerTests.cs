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

public class CriarPessoaHandlerTests
{
    private readonly IPessoaRepository _pessoaRepository =
        Substitute.For<IPessoaRepository>();
    private readonly ILogger<CriarPessoaHandler> _logger = Substitute.For<ILogger<CriarPessoaHandler>>();
    private readonly CriarPessoaHandler _sut;
    
    public CriarPessoaHandlerTests()
    {
        _sut = new CriarPessoaHandler(_pessoaRepository, _logger);
    }
    
    [Fact]
    public async Task CriarPessoaAsync_QuandoCriar_DeveRetornarSucesso()
    {
        //Arrange 
        var pessoa = new CriarPessoaRequest { Nome = "João" };
        var pessoaEntity = new PessoaEntity { Nome = "João" };
        _pessoaRepository.CriarPessoaAsync(It.IsAny<PessoaEntity>())
            .ReturnsForAnyArgs(pessoaEntity);
        
        //Act
        var result = await _sut.Handle(pessoa, CancellationToken.None);
        
        //Assert
        result.Should().BeOfType<Result<CriarPessoaResponse>>().Which
            .Value.Nome.Should().Be(pessoa.Nome);
        result.Should().BeOfType<Result<CriarPessoaResponse>>().Which
            .Value.Nome.Should().NotBeEmpty();
    }
}
