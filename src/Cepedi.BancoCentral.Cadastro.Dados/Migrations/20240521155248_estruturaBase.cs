using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepedi.BancoCentral.Cadastro.Dados.Migrations
{
    /// <inheritdoc />
    public partial class estruturaBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banco",
                columns: table => new
                {
                    IdBanco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeReal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeFantasia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banco", x => x.IdBanco);
                });

            migrationBuilder.CreateTable(
                name: "EstadoCivil",
                columns: table => new
                {
                    IdEstadoCivil = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEstadoCivil = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoCivil", x => x.IdEstadoCivil);
                });

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    IdGenero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeGenero = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.IdGenero);
                });

            migrationBuilder.CreateTable(
                name: "Nacionalidade",
                columns: table => new
                {
                    IdNacionalidade = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeNacionalidade = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nacionalidade", x => x.IdNacionalidade);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    IdPessoa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    EstadoCivil = table.Column<int>(type: "int", nullable: false),
                    Nacionalidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.IdPessoa);
                });

            migrationBuilder.CreateTable(
                name: "TipoRegistro",
                columns: table => new
                {
                    IdTipoRegistro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoRegistro", x => x.IdTipoRegistro);
                });

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    IdEmail = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnderecoEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IdPessoa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.IdEmail);
                    table.ForeignKey(
                        name: "FK_Email_Pessoa_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoa",
                        principalColumn: "IdPessoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    IdEndereco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cep = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IdPessoa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.IdEndereco);
                    table.ForeignKey(
                        name: "FK_Endereco_Pessoa_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoa",
                        principalColumn: "IdPessoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pix",
                columns: table => new
                {
                    IdPix = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChavePix = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TipoPix = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IdPessoa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pix", x => x.IdPix);
                    table.ForeignKey(
                        name: "FK_Pix_Pessoa_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoa",
                        principalColumn: "IdPessoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Telefone",
                columns: table => new
                {
                    IdTelefone = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroTelefone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    IdPessoa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefone", x => x.IdTelefone);
                    table.ForeignKey(
                        name: "FK_Telefone_Pessoa_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoa",
                        principalColumn: "IdPessoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegistroTransacaoBanco",
                columns: table => new
                {
                    IdRegistro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdTipoRegistro = table.Column<int>(type: "int", nullable: false),
                    IdPessoa = table.Column<int>(type: "int", nullable: false),
                    IdBanco = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroTransacaoBanco", x => x.IdRegistro);
                    table.ForeignKey(
                        name: "FK_RegistroTransacaoBanco_Banco_IdBanco",
                        column: x => x.IdBanco,
                        principalTable: "Banco",
                        principalColumn: "IdBanco",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegistroTransacaoBanco_Pessoa_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoa",
                        principalColumn: "IdPessoa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegistroTransacaoBanco_TipoRegistro_IdTipoRegistro",
                        column: x => x.IdTipoRegistro,
                        principalTable: "TipoRegistro",
                        principalColumn: "IdTipoRegistro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Email_IdPessoa",
                table: "Email",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_IdPessoa",
                table: "Endereco",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_Pix_IdPessoa",
                table: "Pix",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroTransacaoBanco_IdBanco",
                table: "RegistroTransacaoBanco",
                column: "IdBanco");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroTransacaoBanco_IdPessoa",
                table: "RegistroTransacaoBanco",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroTransacaoBanco_IdTipoRegistro",
                table: "RegistroTransacaoBanco",
                column: "IdTipoRegistro");

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_IdPessoa",
                table: "Telefone",
                column: "IdPessoa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "EstadoCivil");

            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.DropTable(
                name: "Nacionalidade");

            migrationBuilder.DropTable(
                name: "Pix");

            migrationBuilder.DropTable(
                name: "RegistroTransacaoBanco");

            migrationBuilder.DropTable(
                name: "Telefone");

            migrationBuilder.DropTable(
                name: "Banco");

            migrationBuilder.DropTable(
                name: "TipoRegistro");

            migrationBuilder.DropTable(
                name: "Pessoa");
        }
    }
}
