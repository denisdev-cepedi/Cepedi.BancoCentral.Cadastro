using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepedi.BancoCentral.Cadastro.Dados.Migrations
{
    /// <inheritdoc />
    public partial class estruturaBasePessoaEBanco : Migration
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
                name: "Pessoa",
                columns: table => new
                {
                    IdPessoa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoCivil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nacionalidade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.IdPessoa);
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistroTransacaoBanco");

            migrationBuilder.DropTable(
                name: "Banco");

            migrationBuilder.DropTable(
                name: "Pessoa");
        }
    }
}
