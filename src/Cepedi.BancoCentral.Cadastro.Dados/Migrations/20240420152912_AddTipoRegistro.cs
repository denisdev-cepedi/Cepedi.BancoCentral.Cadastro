using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepedi.BancoCentral.Cadastro.Dados.Migrations
{
    /// <inheritdoc />
    public partial class AddTipoRegistro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoRegistro");
        }
    }
}
