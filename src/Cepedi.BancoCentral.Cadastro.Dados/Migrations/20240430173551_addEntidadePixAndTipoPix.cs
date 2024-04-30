using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepedi.BancoCentral.Cadastro.Dados.Migrations
{
    /// <inheritdoc />
    public partial class addEntidadePixAndTipoPix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoPix",
                columns: table => new
                {
                    IdTipoPix = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPix", x => x.IdTipoPix);
                });

            migrationBuilder.CreateTable(
                name: "Pix",
                columns: table => new
                {
                    IdPix = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChavePix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Agencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Conta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instituicao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipoPix = table.Column<int>(type: "int", nullable: false),
                    TipoPixEntityIdTipoPix = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pix", x => x.IdPix);
                    table.ForeignKey(
                        name: "FK_Pix_TipoPix_TipoPixEntityIdTipoPix",
                        column: x => x.TipoPixEntityIdTipoPix,
                        principalTable: "TipoPix",
                        principalColumn: "IdTipoPix");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pix_TipoPixEntityIdTipoPix",
                table: "Pix",
                column: "TipoPixEntityIdTipoPix");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pix");

            migrationBuilder.DropTable(
                name: "TipoPix");
        }
    }
}
