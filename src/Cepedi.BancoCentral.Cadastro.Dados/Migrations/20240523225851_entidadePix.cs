using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepedi.BancoCentral.Cadastro.Dados.Migrations
{
    /// <inheritdoc />
    public partial class entidadePix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoPixEntityIdTipoPix",
                table: "Pix",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TipoPix",
                columns: table => new
                {
                    IdTipoPix = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoPix = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPix", x => x.IdTipoPix);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pix_TipoPixEntityIdTipoPix",
                table: "Pix",
                column: "TipoPixEntityIdTipoPix");

            migrationBuilder.AddForeignKey(
                name: "FK_Pix_TipoPix_TipoPixEntityIdTipoPix",
                table: "Pix",
                column: "TipoPixEntityIdTipoPix",
                principalTable: "TipoPix",
                principalColumn: "IdTipoPix");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pix_TipoPix_TipoPixEntityIdTipoPix",
                table: "Pix");

            migrationBuilder.DropTable(
                name: "TipoPix");

            migrationBuilder.DropIndex(
                name: "IX_Pix_TipoPixEntityIdTipoPix",
                table: "Pix");

            migrationBuilder.DropColumn(
                name: "TipoPixEntityIdTipoPix",
                table: "Pix");
        }
    }
}
