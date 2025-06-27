using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PosInfnet.InfnetMusic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AjustandoMapeamentoMusicaBanda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musicas_Bandas_Id",
                table: "Musicas");

            migrationBuilder.AddColumn<string>(
                name: "BandaId",
                table: "Musicas",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Musicas_BandaId",
                table: "Musicas",
                column: "BandaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Musicas_Bandas_BandaId",
                table: "Musicas",
                column: "BandaId",
                principalTable: "Bandas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musicas_Bandas_BandaId",
                table: "Musicas");

            migrationBuilder.DropIndex(
                name: "IX_Musicas_BandaId",
                table: "Musicas");

            migrationBuilder.DropColumn(
                name: "BandaId",
                table: "Musicas");

            migrationBuilder.AddForeignKey(
                name: "FK_Musicas_Bandas_Id",
                table: "Musicas",
                column: "Id",
                principalTable: "Bandas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
