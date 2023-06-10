using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoAutoEscola.API.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AtualizadoNomeCampoVeiculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_TipoVeiculos_TipoVeicuoId",
                table: "Veiculos");

            migrationBuilder.RenameColumn(
                name: "TipoVeicuoId",
                table: "Veiculos",
                newName: "TipoVeiculoId");

            migrationBuilder.RenameIndex(
                name: "IX_Veiculos_TipoVeicuoId",
                table: "Veiculos",
                newName: "IX_Veiculos_TipoVeiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_TipoVeiculos_TipoVeiculoId",
                table: "Veiculos",
                column: "TipoVeiculoId",
                principalTable: "TipoVeiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_TipoVeiculos_TipoVeiculoId",
                table: "Veiculos");

            migrationBuilder.RenameColumn(
                name: "TipoVeiculoId",
                table: "Veiculos",
                newName: "TipoVeicuoId");

            migrationBuilder.RenameIndex(
                name: "IX_Veiculos_TipoVeiculoId",
                table: "Veiculos",
                newName: "IX_Veiculos_TipoVeicuoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_TipoVeiculos_TipoVeicuoId",
                table: "Veiculos",
                column: "TipoVeicuoId",
                principalTable: "TipoVeiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
