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

public class AtualizarPessoaHandlerTests
{
    private readonly IPessoaRepository _pessoaRepository =
        Substitute.For<IPessoaRepository>();
    private readonly ILogger<AtualizarPessoaHandler> _logger = Substitute.For<ILogger<AtualizarPessoaHandler>>();
    private readonly AtualizarPessoaHandler _sut;
    private readonly IUnitOfWork _unitOfWork = Substitute.For<IUnitOfWork>();
    
    public AtualizarPessoaHandlerTests()
    {
        _sut = new AtualizarPessoaHandler(_pessoaRepository, _logger, _unitOfWork);
    }
    
    [Fact]
    public async Task AtualizarPessoaAsync_QuandoAtualizar_DeveRetornarSucesso()
    {
        //Arrange 
        var pessoa = new AtualizarPessoaRequest { Nome = "João" };
        var pessoaEntity = new PessoaEntity { Nome = "João" };
        _pessoaRepository.ObterPessoaAsync(It.IsAny<int>()).ReturnsForAnyArgs(new PessoaEntity());
        _pessoaRepository.AtualizarPessoaAsync(It.IsAny<PessoaEntity>())
            .ReturnsForAnyArgs(pessoaEntity);
        
        //Act
        var result = await _sut.Handle(pessoa, CancellationToken.None);
        
        //Assert
        result.Should().BeOfType<Result<AtualizarPessoaResponse>>().Which
            .Value.Nome.Should().Be(pessoa.Nome);
        result.Should().BeOfType<Result<AtualizarPessoaResponse>>().Which
            .Value.Nome.Should().NotBeEmpty();
    }    
}
