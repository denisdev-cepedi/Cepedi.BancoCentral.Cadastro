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

public class DeletarPessoaHandlerTests
{
    private readonly IPessoaRepository _pessoaRepository = Substitute.For<IPessoaRepository>();
    private readonly ILogger<DeletarPessoaHandler> _logger = Substitute.For<ILogger<DeletarPessoaHandler>>();
    private readonly DeletarPessoaHandler _sut;

    public DeletarPessoaHandlerTests()
    {
        _sut = new DeletarPessoaHandler(_pessoaRepository, _logger);
    }

    [Fact]
    public async Task DeletarPessoaAsync_QuandoDeletar_DeveRetornarSucesso()
    {
        //Arrange 
        var pessoa = new DeletarPessoaRequest { Id = 0 };
        _pessoaRepository.ObterPessoaAsync(It.IsAny<int>())
            .ReturnsForAnyArgs(new PessoaEntity());
        _pessoaRepository.DeletarPessoaAsync(It.IsAny<PessoaEntity>())
            .ReturnsForAnyArgs(new PessoaEntity());

        //Act
        var result = await _sut.Handle(pessoa, CancellationToken.None);

        //Assert
        result.Should().BeOfType<Result<DeletarPessoaResponse>>().Which
            .Value.nome.Should().NotBeEmpty();
    }
}
